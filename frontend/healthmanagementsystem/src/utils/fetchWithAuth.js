const fetchWithAuth = async (url, options = {}) => {
  const token = localStorage.getItem('token'); // Retrieve the token from storage
  const headers = {
    'Content-Type': 'application/json',
    ...(token && { Authorization: `Bearer ${token}` }), // Attach token if available
    ...options.headers,
  };

  const response = await fetch(url, { ...options, headers });

  if (!response.ok) {
    throw new Error(response.statusText);
  }

  // Convert response to JSON and log the result
  const data = await response.json(); // Read the response body once
  return data; // Return the parsed data
};

export default fetchWithAuth;