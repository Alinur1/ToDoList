import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { addUser } from '../services/userService';

function AddUser() {
  const [user, setUser] = useState({ name: '', email: '' });
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleChange = (e) => {
    setUser({ ...user, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await addUser(user);
      navigate('/');
    } catch (err) {
      setError('Failed to add user. Please try again.');
    }
  };

  return (
    <div>
      <h1>Add User</h1>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <form onSubmit={handleSubmit}>
        <div>
          <label>Name:</label>
          <input
            type="text"
            name="name"
            value={user.name}
            onChange={handleChange}
            required
          />
        </div>
        <div>
          <label>Email:</label>
          <input
            type="email"
            name="email"
            value={user.email}
            onChange={handleChange}
            required
          />
        </div>
        <button type="submit">Add User</button>
      </form>
    </div>
  );
}

export default AddUser;
