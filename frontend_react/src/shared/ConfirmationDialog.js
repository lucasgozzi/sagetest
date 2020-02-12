import React from 'react';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';


export default function StatusDialog(props) {
    const [open, setOpen] = React.useState(true);
    const {name, okFunction, cancelFunction} = props;

    const handleClose = () => {
        setOpen(false);
        cancelFunction();
    };

    const handleOk = () => {
        okFunction();
        setOpen(false);
    };

    return (
        <div>
            <Dialog
                open={open}
                onClose={handleClose}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
            >
                <DialogTitle id="alert-dialog-title">Deletar pessoa</DialogTitle>
                <DialogContent>
                    <DialogContentText id="alert-dialog-description">
                       Você deseja realmente deletar {name}?
                    </DialogContentText>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleOk} color="primary" autoFocus>
                        Ok
                    </Button>
                    <Button onClick={handleClose} color="secondary" autoFocus>
                        Cancelar
                    </Button>
                </DialogActions>
            </Dialog>
        </div>
    );
}
