import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { fetchTasks, deleteTask } from '../services/taskService';

function TaskList() {
  const [tasks, setTasks] = useState([]);
  const [error, setError] = useState('');
  const navigate = useNavigate();

  useEffect(() => {
    const getTasks = async () => {
      try {
        const response = await fetchTasks();
        setTasks(response.data);
      } catch (err) {
        setError('Failed to fetch tasks.');
      }
    };
    getTasks();
  }, []);

  const handleDelete = async (id) => {
    try {
      await deleteTask(id);
      setTasks(tasks.filter((task) => task.task_id !== id));
    } catch (err) {
      setError('Failed to delete task.');
    }
  };

  return (
    <div>
      <h1>Task List</h1>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <button onClick={() => navigate('/add-task')}>Add Task</button>

      <table>
        <thead>
          <tr>
            <th>Task ID</th>
            <th>Task Name</th>
            <th>Task Description</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {tasks.map((task) => (
            <tr key={task.task_id}>
              <td>{task.task_id}</td>
              <td>{task.task_name}</td>
              <td>{task.task_description}</td>
              <td>
                <button onClick={() => navigate(`/tasks/${task.task_id}`)}>View</button>
                <button onClick={() => navigate(`/update-task/${task.task_id}`)}>Edit</button>
                <button onClick={() => handleDelete(task.task_id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default TaskList;
