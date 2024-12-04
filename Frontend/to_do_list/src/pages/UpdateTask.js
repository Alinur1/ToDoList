import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { fetchTaskById, updateTask } from '../services/taskService';

function UpdateTask() {
  const { id } = useParams();
  const [task, setTask] = useState({ task_name: '', task_description: '' });
  const [error, setError] = useState('');
  const navigate = useNavigate();

  useEffect(() => {
    const getTask = async () => {
      try {
        const response = await fetchTaskById(id);
        setTask(response.data);
      } catch (err) {
        setError('Failed to fetch task details.');
      }
    };
    getTask();
  }, [id]);

  const handleChange = (e) => {
    setTask({ ...task, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await updateTask(id, task);
      navigate('/');
    } catch (err) {
      setError('Failed to update task.');
    }
  };

  return (
    <div>
      <h1>Update Task</h1>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <form onSubmit={handleSubmit}>
        <label>Name:</label>
        <input name="task_name" value={task.task_name} onChange={handleChange} required />
        <label>Description:</label>
        <textarea name="task_description" value={task.task_description} onChange={handleChange} required />
        <button type="submit">Update Task</button>
      </form>
    </div>
  );
}

export default UpdateTask;
