import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { addUser } from '../services/userService';

function AddUser() {
  const [user, setUser] = useState({ full_name: '', username: '', email: '', password: '', role: '' });
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
            name="username"
            value={user.username}
            onChange={handleChange}
            required
          />
        </div>
        <div>
          <label>Username:</label>
          <input
            type="text"
            name="username"
            value={user.username}
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
        <div>
          <label>Password:</label>
          <input
            type="password"
            name="password"
            value={user.password}
            onChange={handleChange}
            required
          />
        </div>
        <div>
          <label>Role:</label>
          <input
            type="text"
            name="role"
            value={user.role}
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