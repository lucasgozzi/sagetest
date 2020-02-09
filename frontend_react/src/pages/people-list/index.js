import React, { useEffect, useState } from 'react';
import '../../App.css';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Container from '@material-ui/core/Container';
import Title from '../../shared/Title';
import Formatter from '../../shared/formatDocument';
import { useHistory, useLocation } from "react-router-dom";
import PeopleService from "../../services/peopleService";
import StatusDialog from '../../shared/StatusDialog';

export default function PeopleList(props) {
    const { state } = useLocation();

    const history = useHistory();
    const [peoples, setPeoples] = useState([]);

    useEffect(() => {
        PeopleService.getPeoples({}).then(response => {
            if (response.data) {
                setPeoples(response.data);
            }
        });
    }, []);

    function updatePeople(people) {
        history.push(`/new-update/${people.id}`);
    }

    return (
        <Container maxWidth="md">
            {state && state.success && <StatusDialog />}
            <div className="clear"></div>
            <Title>Pessoas</Title>
            <Table size="small">
                <TableHead>
                    <TableRow>
                        <TableCell>Nome</TableCell>
                        <TableCell>E-mail</TableCell>
                        <TableCell>Documento</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {peoples.map(row => (
                        <TableRow key={row.id} onClick={() => updatePeople(row)}>
                            <TableCell>{row.name}</TableCell>
                            <TableCell>{row.email}</TableCell>
                            <TableCell>{Formatter.addMask(row.document)}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </Container>
    );
}
