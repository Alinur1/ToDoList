import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getUserById, updateUser } from '../services/userService';

function UpdateUser() {
  const { id } = useParams();
  const [user, setUser] = useState({ full_name: '', username: '', email: '', password: '', role: '' });
  const [error, setError] = useState('');
  const navigate = useNavigate();

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const { data } = await getUserById(id);
        setUser(data);
      } catch (err) {
        setError('Failed to fetch user data.');
      }
    };
    fetchUser();
  }, [id]);

  const handleChange = (e) => {
    setUser({ ...user, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await updateUser(id, user);
      navigate('/');
    } catch (err) {
      setError('Failed to update user. Please try again.');
    }
  };

  return (
    <div>
      <h1>Update User</h1>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <form onSubmit={handleSubmit}>
        <div>
          <label>Name:</label>
          <input
            type="text"
            name="full_name"
            value={user.full_name}
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
        <button type="submit">Update User</button>
      </form>
    </div>
  );
}

export default UpdateUser;
