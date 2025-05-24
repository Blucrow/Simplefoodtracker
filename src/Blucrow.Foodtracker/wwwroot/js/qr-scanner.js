window.qrScannerInterop = {
    scanner: null,
    startScanner: function (elementId, dotNetObjRef) {
        const config = { fps: 10, qrbox: 250 };

        this.scanner = new Html5Qrcode(elementId);

        this.scanner.start(
            { facingMode: "environment" },
            config,
            (decodedText, decodedResult) => {
                dotNetObjRef.invokeMethodAsync('OnBarcodeScanned', decodedText);
            },
            (errorMessage) => {
                // Ignore scan errors
                console.log("Scan error:", errorMessage);
            }
        ).catch(err => {
            console.error("Scanner start error:", err);
        });
    },
    stopScanner: function () {
        if (this.scanner) {
            this.scanner.stop().then(() => {
                this.scanner.clear();
            }).catch(err => {
                console.error("Stop error:", err);
            });
        }
    }
};