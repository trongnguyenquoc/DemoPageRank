import React, {
  useEffect,
  useState,
  forwardRef,
  useImperativeHandle,
} from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import Container from "@mui/material/Container";
import { formatDateTime } from "../../helper/DateTimeConvert";

const SearchHistory = forwardRef((props, ref) => {
  const apiUrl = process.env.REACT_APP_API_URL;
  const [history, setHistory] = useState([]);

  const fetchHistory = async () => {
    try {
      const response = await fetch(`${apiUrl}/pageranks`);
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      const data = await response.json();
      setHistory(data);
    } catch (error) {
      console.error("Error fetching history:", error);
    }
  };

  useImperativeHandle(ref, () => ({
    fetchHistory,
  }));

  return (
    <Container maxWidth="md" sx={{ p: 5 }}>
      {history.length > 0 && (
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>Phrase</TableCell>
              <TableCell align="left">Rank</TableCell>
              <TableCell align="right">Date</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {history.map((row) => (
              <TableRow
                key={row.id}
                sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {row.phrase}
                </TableCell>
                <TableCell align="left"># {row.rank}</TableCell>
                <TableCell align="right">{formatDateTime(row.createdDate)}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      )}
    </Container>
  );
});

export default SearchHistory;
