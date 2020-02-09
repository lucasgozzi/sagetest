import React from 'react';
import { FormControl, InputLabel, FormHelperText, Input, Grid } from '@material-ui/core';
import searchZipcode from '../../services/cepService';

export default function EditAddress(props) {
    const {
        setZipcode, zipcode, state, setState, city, setCity,
        neighborhood, setNeighborhood, address, setAddress,
        number, setNumber, complement, setComplement,
    } = props;

    function changeZipCode() {
        searchZipcode(zipcode).then(response => {
            if(response.data){
                setState(response.data.uf);
                setCity(response.data.cidade);
                setNeighborhood(response.data.bairro);
                setAddress(response.data.endereco);
            }
        });
    }

    return (
        <>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <FormControl>
                        <InputLabel htmlFor="zipCode">CEP*:</InputLabel>
                        <Input id="zipCode"
                            value={zipcode}
                            onBlur={changeZipCode} onChange={(e) => setZipcode(e.target.value)} 
                            aria-describedby="cep-hint" />
                        <FormHelperText id="cep-hint">Digite seu CEP.</FormHelperText>
                    </FormControl>
                </Grid>
                <Grid item xs={3}>
                    <FormControl>
                        <InputLabel htmlFor="state">Estado:</InputLabel>
                        <Input id="state"
                            value={state} aria-describedby="state-hint" readOnly={true} />
                        <FormHelperText id="state-hint">Seu estado</FormHelperText>
                    </FormControl>
                </Grid>
                <Grid item xs={9}>
                    <FormControl>
                        <InputLabel htmlFor="city">Cidade:</InputLabel>
                        <Input id="city"
                            value={city} aria-describedby="city-hint" readOnly={true} />
                        <FormHelperText id="city-hint">Sua cidade.</FormHelperText>
                    </FormControl>
                </Grid>
                <Grid item xs={6}>
                    <FormControl>
                        <InputLabel htmlFor="neighborhood">Bairro:</InputLabel>
                        <Input id="neighborhood"
                            value={neighborhood} aria-describedby="neighborhood-hint" readOnly={true} />
                        <FormHelperText id="neighborhood-hint">Seu bairro</FormHelperText>
                    </FormControl>
                </Grid>
                <Grid item xs={6}>
                    <FormControl>
                        <InputLabel htmlFor="address">Logradouro:</InputLabel>
                        <Input id="address"
                            value={address} aria-describedby="address-hint" readOnly={true} />
                        <FormHelperText id="address-hint">Seu logradouro</FormHelperText>
                    </FormControl>
                </Grid>
                <Grid item xs={3}>
                    <FormControl>
                        <InputLabel htmlFor="number">Número:</InputLabel>
                        <Input id="number"
                            value={number} onChange={(e) => setNumber(e.target.value)} aria-describedby="number-hint" />
                        <FormHelperText id="number-hint">Seu número de casa</FormHelperText>
                    </FormControl>
                </Grid>
                <Grid item xs={9}>
                    <FormControl>
                        <InputLabel htmlFor="complement">Complemento:</InputLabel>
                        <Input id="complement"
                            value={complement} onChange={(e) => setComplement(e.target.value)} aria-describedby="complement-hint" />
                        <FormHelperText id="complement-hint">Se houver complemento ex.: Apto xxxx</FormHelperText>
                    </FormControl>
                </Grid>
            </Grid>
        </>
    );
}
