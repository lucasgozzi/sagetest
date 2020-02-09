import React, { useEffect, useState } from 'react';
import Stepper from '@material-ui/core/Stepper';
import Step from '@material-ui/core/Step';
import StepLabel from '@material-ui/core/StepLabel';
import Button from '@material-ui/core/Button';
import { useParams } from "react-router-dom";
import Container from '@material-ui/core/Container';
import './styles.css';
import EditPeople from '../../shared/crud-people/people-data';
import EditAddress from '../../shared/crud-people/address-data';
import PeopleService from "../../services/peopleService";
import Formatter from '../../shared/formatDocument';
import { useHistory } from "react-router-dom";

export default function PeopleUpsert() {
    //#region init component
    const history = useHistory();
    const [email, setEmail] = useState('');
    const [name, setName] = useState('');
    const [document, setDocument] = useState('');
    const [mother, setMother] = useState('');
    const [father, setFather] = useState('');
    const [addressId, setAddressId] = useState('');
    const [zipcode, setZipcode] = useState('');
    const [state, setState] = useState('');
    const [city, setCity] = useState('');
    const [address, setAddress] = useState('');
    const [neighborhood, setNeighborhood] = useState('');
    const [number, setNumber] = useState('');
    const [complement, setComplement] = useState('');
    const [activeStep, setActiveStep] = useState(0);
    const steps = getSteps();
    let { id } = useParams();

    useEffect(() => {
        if (id) {
            // get from rest api
            PeopleService.getPeople(id).then((response) => {
                if (response.data) {
                    const data = response.data;
                    setEmail(data.email);
                    setName(data.name);
                    setDocument(Formatter.addMask(data.document));
                    setMother(data.mother);
                    setFather(data.father);
                    if (data.address) {
                        setAddressId(data.address.id);
                        setZipcode(data.address.zipcode);
                        setState(data.address.state);
                        setCity(data.address.city);
                        setAddress(data.address.address);
                        setNeighborhood(data.address.neighborhood);
                        setNumber(data.address.number);
                        setComplement(data.address.complement);
                    }
                }
            });
        }
    }, [])
    //#endregion

    //#region stepper fncs
    function getSteps() {
        return ['Dados da Pessoa', 'Endereço'];
    }

    function getStepContent(step) {
        switch (step) {
            case 0:
                return <div className="content"><EditPeople
                    name={name} setName={setName} email={email} setEmail={setEmail} document={document} setDocument={setDocument}
                    mother={mother} setMother={setMother} father={father} setFather={setFather} /></div>;
            case 1:
                return <div className="content"><EditAddress zipcode={zipcode} setZipcode={setZipcode}
                    state={state} setState={setState} city={city} setCity={setCity} neighborhood={neighborhood}
                    setNeighborhood={setNeighborhood} address={address} setAddress={setAddress} number={number} setNumber={setNumber}
                    complement={complement} setComplement={setComplement} /></div>;
            default:
                return 'Unknown step';
        }
    }
    const handleNext = () => {
        if (activeStep === 1) {

            const dto = {
                id, name, email, document: Formatter.removeMask(document), mother, father,
                address: { id: addressId, zipcode, state, city, neighborhood, address, number, complement }
            }
            if (id) {
                PeopleService.updatePeople(id, dto).then(response => {
                    history.push('/', { success: true });
                }, rej => {
                    console.log('rejected: ');
                });
            } else {
                PeopleService.addPeople(dto).then(response => {
                    history.push('/', { success: true }); 
                }, rej => {
                    console.log('rejected: ');
                });
            }
        } else {
            setActiveStep(prevActiveStep => prevActiveStep + 1);
        }
    };

    const handleBack = () => {
        setActiveStep(prevActiveStep => prevActiveStep - 1);
    };
    //#endregion

    //#region render()
    return (
        <Container maxWidth="md" className="main">
            <Stepper activeStep={activeStep}>
                {steps.map((label, index) => {
                    const stepProps = {};
                    const labelProps = {};
                    return (
                        <Step key={label} {...stepProps}>
                            <StepLabel {...labelProps}>{label}</StepLabel>
                        </Step>
                    );
                })}
            </Stepper>
            <div>
                <div>
                    {getStepContent(activeStep)}
                    <div className="actions">
                        <Button disabled={activeStep === 0} onClick={handleBack}
                            variant="contained"
                            color="secondary"> Voltar</Button>

                        <Button
                            variant="contained"
                            color="primary"
                            onClick={handleNext}
                        >
                            {activeStep === steps.length - 1 ? 'Salvar' : 'Próximo'}
                        </Button>
                    </div>
                    <div className="spacer"></div>
                </div>
            </div>
        </Container>
    );
    //#endregion
}
