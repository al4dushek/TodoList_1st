document.addEventListener('DOMContentLoaded', () => {
    const tasks = document.querySelectorAll('.task');
    const noTasksMessage = document.getElementById('no-tasks-message');

    const toggleVisibility = (element, show) => {
        if (element) {
            element.classList.toggle('d-none', !show);
        }
    };

    // Обновить сообщение о задачах
    const updateNoTasksMessage = () => {
        const hasTasks = document.querySelectorAll('.task').length > 0;
        toggleVisibility(noTasksMessage, !hasTasks);
    };

    // Редактирование задачи
    const setupEditTask = (task) => {
        const id = task.dataset.id;
        const editBtn = task.querySelector('.edit');
        const cancelBtn = task.querySelector('.cancel');
        const saveBtn = task.querySelector('.save');
        const taskNameLabel = task.querySelector('.task-name-label');
        const editNameInput = task.querySelector('.edit-name');
        const editableGroup = task.querySelector('.editable-group');

        if (editBtn) {
            editBtn.addEventListener('click', () => {
                toggleVisibility(editBtn, false);
                toggleVisibility(taskNameLabel, false);
                toggleVisibility(editableGroup, true);
                editNameInput.value = taskNameLabel.textContent.trim(); // Pre-fill input
            });
        }

        if (cancelBtn) {
            cancelBtn.addEventListener('click', () => {
                toggleVisibility(editBtn, true);
                toggleVisibility(taskNameLabel, true);
                toggleVisibility(editableGroup, false);
            });
        }

        saveBtn?.addEventListener('click', () => {
            const newTaskName = editNameInput.value.trim();
            if (!newTaskName) {
                alert('Task name cannot be empty.');
                return;
            }

            fetch('/Home/UpdateNameAsync', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-CSRF-TOKEN': document.querySelector('input[name="__RequestVerificationToken"]').value
                },
                body: JSON.stringify({ id, name: newTaskName })
            })
                .then((response) => response.json())
                .then((data) => {
                    if (data.success) {
                        taskNameLabel.textContent = data.taskName;
                        toggleVisibility(editBtn, true);
                        toggleVisibility(taskNameLabel, true);
                        toggleVisibility(editableGroup, false);
                    } else {
                        alert(data.message || 'Failed to save changes.');
                    }
                })
                .catch((error) => {
                    console.error('Error saving task:', error);
                    alert('An error occurred while saving the task.');
                });
        });
    };

    // Удаление задачи
    const setupDeleteTask = (task) => {
        const id = task.dataset.id;
        const deleteBtn = task.querySelector('.delete');

        if (deleteBtn) {
            deleteBtn.addEventListener('click', () => {
                if (!confirm('Are you sure you want to delete this task?')) {
                    return;
                }

                fetch('/Home/DeleteAsync', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'X-CSRF-TOKEN': document.querySelector('input[name="__RequestVerificationToken"]').value
                    },
                    body: JSON.stringify({ id })
                })
                    .then((response) => response.json())
                    .then((data) => {
                        if (data.success) {
                            task.remove();
                            updateNoTasksMessage();
                        } else {
                            alert(data.message || 'Failed to delete task.');
                        }
                    })
                    .catch((error) => {
                        console.error('Error deleting task:', error);
                        alert('An error occurred while deleting the task.');
                    });
            });
        }
    };

    if (tasksContainer.length > 0) {
        tasksContainer.forEach((task) => {
            setupEditTask(task);
            setupDeleteTask(task);
        });
    }

    updateNoTasksMessage();
});
