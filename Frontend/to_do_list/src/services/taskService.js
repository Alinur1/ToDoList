import axios from 'axios';

const API_URL = 'https://localhost:7001/api/TaskList';

export const fetchTasks = async () => {
  return await axios.get(API_URL);
};

export const fetchTaskById = async (id) => {
  return await axios.get(`${API_URL}/${id}`);
};

export const addTask = async (task) => {
  return await axios.post(API_URL, task);
};

export const updateTask = async (id, task) => {
  return await axios.put(`${API_URL}/${id}`, task);
};

export const deleteTask = async (id) => {
  return await axios.delete(`${API_URL}/${id}`);
};
