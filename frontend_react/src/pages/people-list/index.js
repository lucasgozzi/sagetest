import React, { useEffect, useState } from 'react';
import '../../App.css';
import Table from '@material-ui/core/Table';
import Button from '@material-ui/core/Button';
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
import DeleteForeverSharpIcon from '@material-ui/icons/DeleteForeverSharp';
import ConfirmationDialog from '../../shared/ConfirmationDialog';

export default function PeopleList(props) {
    let { state } = useLocation();

    const history = useHistory();
    const [peoples, setPeoples] = useState([]);
    const [showSuccess, setShowSuccess] = useState(false);
    const [itemToDelete, setItemToDelete] = useState(null);

    function refreshPeople() {
        PeopleService.getPeoples({}).then(response => {
            if (response.data) {
                setPeoples(response.data);
            }
        });
    }
    useEffect(() => {
        refreshPeople();
    }, []);

    function updatePeople(people) {
        history.push(`/new-update/${people.id}`);
    }

    function remove(e, row) {
        e.stopPropagation();
        e.nativeEvent.stopImmediatePropagation();
        setItemToDelete(row);
    }

    function cancel() {
        setItemToDelete(null);
    }

    function deleteConfirmed() {
        PeopleService.removePeople(itemToDelete.id).then(response => {
            if (response.status === 204) {
                refreshPeople();
                setShowSuccess(true);
            }
            setItemToDelete(null);
        })
    }

    if (!showSuccess && state && state.success) {
        setShowSuccess(true);
    }

    return (
        <Container maxWidth="md">
            {itemToDelete && <ConfirmationDialog
                name={itemToDelete.name}
                okFunction={() => deleteConfirmed(itemToDelete.id)}
                cancelFunction={() => cancel()}
            />}
            {showSuccess && <StatusDialog resetSuccess={setShowSuccess} />}
            <div className="clear"></div>
            <Title>Pessoas</Title>
            <Table size="small">
                <TableHead>
                    <TableRow>
                        <TableCell>Nome</TableCell>
                        <TableCell>E-mail</TableCell>
                        <TableCell>Documento</TableCell>
                        <TableCell></TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {peoples.map(row => (
                        <TableRow key={row.id} onClick={() => updatePeople(row)}>
                            <TableCell>{row.name}</TableCell>
                            <TableCell>{row.email}</TableCell>
                            <TableCell>{Formatter.addMask(row.document)}</TableCell>
                            <TableCell><Button onClick={(e) => remove(e, row)}> <DeleteForeverSharpIcon /></Button></TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </Container>
    );
}
