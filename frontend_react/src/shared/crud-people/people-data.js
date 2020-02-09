import React from 'react';
import { FormControl, InputLabel, FormHelperText, Input, Grid } from '@material-ui/core';
import Formatter from '../../shared/formatDocument';

export default function EditPeople(props) {
    const {
        setName, name, setEmail, email,
        setDocument, document, setMother,
        mother, setFather, father
    } = props;

    function handleNumberEntry(val) {
        if (val.length <= 19)
            setDocument(Formatter.addMask(Formatter.removeMask(val)));
    }

    return (
        <>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <FormControl>
                        <InputLabel htmlFor="email">E-mail*:</InputLabel>
                        <Input id="email" type="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)} aria-describedby="email-hint" required={true} />
                        <FormHelperText id="email-hint">Seu endereço de e-mail.</FormHelperText>
                    </FormControl>
                </Grid>
                <Grid item xs={6}>
                    <FormControl>
                        <InputLabel htmlFor="name">Nome*:</InputLabel>
                        <Input id="name"
                            value={name}
                            onChange={(e) => setName(e.target.value)} aria-describedby="name-hint" required={true} />
                        <FormHelperText id="name-hint">Digite seu nome.</FormHelperText>
                    </FormControl>
                </Grid>
                <Grid item xs={6}>
                    <FormControl>
                        <InputLabel htmlFor="document">CPF/CNPJ*:</InputLabel>
                        <Input id="document"
                            value={document}
                            onChange={(e) => handleNumberEntry(e.target.value)} aria-describedby="doc-hint" required={true} />
                        <FormHelperText id="doc-hint">Seu documento.</FormHelperText>
                    </FormControl>
                </Grid>
                <Grid item xs={12}>
                    <FormControl>
                        <InputLabel htmlFor="mother">Mãe:</InputLabel>
                        <Input id="mother"
                            value={mother}
                            onChange={(e) => setMother(e.target.value)} aria-describedby="mother-hint" />
                        <FormHelperText id="mother-hint">Nome da mãe</FormHelperText>
                    </FormControl>
                </Grid>
                <Grid item xs={12}>
                    <FormControl>
                        <InputLabel htmlFor="father">Pai:</InputLabel>
                        <Input id="father"
                            value={father}
                            onChange={(e) => setFather(e.target.value)} aria-describedby="father-hint" />
                        <FormHelperText id="father-hint">Nome do pai</FormHelperText>
                    </FormControl>
                </Grid>
            </Grid>
        </>
    );
}
