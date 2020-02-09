class Formatter {
    removeMask = (document) => {
        return document.replace(/[^\d]/g, '');
    }
    addMask = (document) => {
        if (document.length === 11) {
            document = document.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
        }
        // cnpj
        if (document.length === 15) {
            document = document.replace(/(\d{3})(\d{3})(\d{3})(\d{4})(\d{2})/, "$1.$2.$3/$4-$5");
        }
        return document;
    }
}

export default new Formatter();
