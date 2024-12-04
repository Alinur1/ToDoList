import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { addTask } from '../services/taskService';

function AddTask() {
  const [task, setTask] = useState({ task_name: '', task_description: '' });
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleChange = (e) => {
    setTask({ ...task, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await addTask(task);
      navigate('/');
    } catch (err) {
      setError('Failed to add task.');
    }
  };

  return (
    <div>
      <h1>Add Task</h1>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <form onSubmit={handleSubmit}>
        <label>Name:</label>
        <input name="task_name" value={task.task_name} onChange={handleChange} required />
        <label>Description:</label>
        <textarea name="task_description" value={task.task_description} onChange={handleChange} required />
        <button type="submit">Add Task</button>
      </form>
    </div>
  );
}

export default AddTask;
