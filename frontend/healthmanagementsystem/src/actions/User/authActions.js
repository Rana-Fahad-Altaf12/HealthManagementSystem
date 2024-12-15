const API_URL = 'https://localhost:7263/api/users'; // Replace with your API URL

export const loginUserAction = async (credentials) => {
  const response = await fetch(`${API_URL}/login`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(credentials),
  });

  if (!response.ok) {
    const errorData = await response.json();
    throw new Error(errorData.message || 'Something went wrong');
  }
  
  return response.json();
};

export const logoutUserAction = async () => {
  // Implement logout logic here (if applicable)
};