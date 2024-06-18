const formatDateTime = (timeString) => {
  // Transform 2024-06-16T16:43:18.1668131Z to 2024-06-16T16:43:18 -- just simple way
  const index = timeString.indexOf(".");
  return index !== -1 ? timeString.slice(0, index) : timeString;
};

export { formatDateTime };
