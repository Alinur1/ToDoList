import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { fetchTaskById } from '../services/taskService';

function TaskDetails() {
  const { id } = useParams();
  const [task, setTask] = useState(null);
  const [error, setError] = useState('');

  useEffect(() => {
    const getTask = async () => {
      try {
        const response = await fetchTaskById(id);
        setTask(response.data);
      } catch (err) {
        setError('Task not found.');
      }
    };
    getTask();
  }, [id]);

  if (error) return <p style={{ color: 'red' }}>{error}</p>;
  if (!task) return <p>Loading...</p>;

  return (
    <div>
      <h1>Task Details</h1>
      <p><strong>Task Name:</strong> {task.task_name}</p>
      <p><strong>Description:</strong> {task.task_description}</p>
    </div>
  );
}

export default TaskDetails;
