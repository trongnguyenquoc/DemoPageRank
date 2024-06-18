import React, { useState } from "react";
import Button from "@mui/material/Button";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import Stack from "@mui/material/Stack";
import Container from "@mui/material/Container";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import Typography from "@mui/material/Typography";

const SearchBox = ({ onSaveSuccess }) => {
  const apiUrl = process.env.REACT_APP_API_URL;
  const [phraseSearch, setPhraseSearch] = useState("");
  const [result, setResult] = useState();

  const handleInputChange = (event) => {
    setPhraseSearch(event.target.value);
  };

  const handleSearch = async () => {
    try {
      const response = await fetch(`${apiUrl}/pageranks`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ phraseSearch }),
      });

      if (!response.ok) {
        throw new Error("Network response was not ok");
      }

      const data = await response.json();
      setResult(data);
      onSaveSuccess();
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  };

  return (
    <Container maxWidth="md" sx={{ p: 5 }}>
      <Box component="section" sx={{ p: 2, border: "1px dashed grey" }}>
        <Stack direction="row" spacing={2}>
          <TextField
            id="outlined-basic"
            label="Search"
            variant="outlined"
            fullWidth
            value={phraseSearch}
            onChange={handleInputChange}
          />
          <Button variant="contained" sx={{ px: 5 }} onClick={handleSearch}>
            Search
          </Button>
        </Stack>
      </Box>
      {result && (
        <Card sx={{ maxWidth: 275, mt: 5 }}>
          <CardContent>
            <Typography variant="h5" component="div">
              Rank # {result && result.rank}
            </Typography>
          </CardContent>
        </Card>
      )}
    </Container>
  );
};

export default SearchBox;
