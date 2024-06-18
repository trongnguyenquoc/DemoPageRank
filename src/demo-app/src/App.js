import React, { useRef } from 'react';
import './App.css';
import SearchBox from './components/search-box/SearchBox';
import Container from '@mui/material/Container';
import SearchHistory from  './components/search-history/SearchHistory';

function App() {
  const listSearchHistoryRef = useRef();
  
  const handleSaveSuccess = () => {
    listSearchHistoryRef.current.fetchHistory();
};

  return (
    <div className="App">
      <Container maxWidth="lg">
        <SearchBox onSaveSuccess={handleSaveSuccess} />
        <SearchHistory ref={listSearchHistoryRef}  />
      </Container>
    </div>
  );
}

export default App;
