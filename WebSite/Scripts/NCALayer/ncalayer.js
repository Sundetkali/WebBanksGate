Nat.Classes.NCALayerWebSocket = function() {
    var ncaLayerCallback = null;
    var me = this;

    this.Initialize = function() {
        if (this.initialized)
            return;

        try {
            this.webSocket = new WebSocket('wss://127.0.0.1:13579/');
        }
        catch(e) {
            console.error(e);
            this.initialized = false;
            this.webSocket = null;
        }

        if (!this.webSocket)
            return;

        this.webSocket.onopen = function(event) {
            console.log("Connection opened");
            me.initialized = true;
            me.changeLocale(window.currentCulture);
        };

        this.webSocket.onclose = function(e) {
            me.initialized = false;
            me.webSocket = null;
            console.log('Code: ' + e.code + ' Reason: ' + e.reason);
            if (e.wasClean) {
                console.log('connection has been closed');
            } else {
                console.log('Connection error');
                if (e.timeStamp < 1000000)
                    me.openDialog();
            }
        };

        this.webSocket.onmessage = function(event) {
            var result = JSON.parse(event.data);

            if (result != null) {
                var rw = {
                    code: result['code'],
                    message: result['message'],
                    responseObject: result['responseObject'],
                    getResult: function() {
                        return this.result;
                    },
                    getMessage: function() {
                        return this.message;
                    },
                    getResponseObject: function() {
                        return this.responseObject;
                    },
                    getCode: function() {
                        return this.code;
                    }
                };
                if (ncaLayerCallback != null) {
                    ncaLayerCallback(rw);
                }
            }
            // console.log(event);
        };
    };

    this.openDialog = function () {
        if (confirm("Ошибка при подключении к NCALayer. Запустите NCALayer и нажмите ОК") === true) {
            this.Initialize();
        }
    }

    this.getActiveTokens = function (callBack) {
        this.Initialize();
        var getActiveTokens = {
            "module": "kz.gov.pki.knca.commonUtils",
            "method": "getActiveTokens"
        };
        ncaLayerCallback = callBack;
        this.webSocket.send(JSON.stringify(getActiveTokens));
    }

    this.getKeyInfo = function (storageName, callBack) {
        this.Initialize();
        var getKeyInfo = {
            "module": "kz.gov.pki.knca.commonUtils",
            "method": "getKeyInfo",
            "args": [storageName]
        };
        ncaLayerCallback = callBack;
        this.webSocket.send(JSON.stringify(getKeyInfo));
    }

    this.signXml = function (storageName, keyType, xmlToSign, callBack) {
        this.Initialize();
        var signXml = {
            "module": "kz.gov.pki.knca.commonUtils",
            "method": "signXml",
            "args": [storageName, keyType, xmlToSign, "", ""]
        };
        ncaLayerCallback = callBack;
        this.webSocket.send(JSON.stringify(signXml));
    }

    this.signXmls = function (storageName, keyType, xmlsToSign, callBack) {
        this.Initialize();
        var signXmls = {
            "module": "kz.gov.pki.knca.commonUtils",
            "method": "signXmls",
            "args": [storageName, keyType, xmlsToSign, "", ""]
        };
        ncaLayerCallback = callBack;
        this.webSocket.send(JSON.stringify(signXmls));
    }

    this.createCAdESFromFile = function (storageName, keyType, filePath, flag, callBack) {
        this.Initialize();
        var createCAdESFromFile = {
            "module": "kz.gov.pki.knca.commonUtils",
            "method": "createCAdESFromFile",
            "args": [storageName, keyType, filePath, flag]
        };
        ncaLayerCallback = callBack;
        this.webSocket.send(JSON.stringify(createCAdESFromFile));
    }

    this.createCAdESFromBase64 = function (storageName, keyType, base64ToSign, flag, callBack) {
        this.Initialize();
        var createCAdESFromBase64 = {
            "module": "kz.gov.pki.knca.commonUtils",
            "method": "createCAdESFromBase64",
            "args": [storageName, keyType, base64ToSign, flag]
        };
        ncaLayerCallback = callBack;
        this.webSocket.send(JSON.stringify(createCAdESFromBase64));
    }

    this.createCAdESFromBase64Hash = function createCAdESFromBase64Hash(storageName, keyType, base64ToSign, callBack) {
        this.Initialize();
        var createCAdESFromBase64Hash = {
            "module": "kz.gov.pki.knca.commonUtils",
            "method": "createCAdESFromBase64Hash",
            "args": [storageName, keyType, base64ToSign]
        };
        ncaLayerCallback = callBack;
        this.webSocket.send(JSON.stringify(createCAdESFromBase64Hash));
    }

    this.applyCAdEST = function (storageName, keyType, cmsForTS, callBack) {
        this.Initialize();
        var applyCAdEST = {
            "module": "kz.gov.pki.knca.commonUtils",
            "method": "applyCAdEST",
            "args": [storageName, keyType, cmsForTS]
        };
        ncaLayerCallback = callBack;
        this.webSocket.send(JSON.stringify(applyCAdEST));
    }

    this.showFileChooser = function (fileExtension, currentDirectory, callBack) {
        this.Initialize();
        var showFileChooser = {
            "module": "kz.gov.pki.knca.commonUtils",
            "method": "showFileChooser",
            "args": [fileExtension, currentDirectory]
        };
        ncaLayerCallback = callBack;
        this.webSocket.send(JSON.stringify(showFileChooser));
    }

    this.changeLocale = function (language) {
        this.Initialize();
        var changeLocale = {
            "module": "kz.gov.pki.knca.commonUtils",
            "method": "changeLocale",
            "args": [language]
        };
        ncaLayerCallback = null;
        this.webSocket.send(JSON.stringify(changeLocale));
    }

    this.createCMSSignatureFromFile = function (storageName, keyType, filePath, flag, callBack) {
        this.Initialize();
        var createCMSSignatureFromFile = {
            "module": "kz.gov.pki.knca.commonUtils",
            "method": "createCMSSignatureFromFile",
            "args": [storageName, keyType, filePath, flag]
        };
        ncaLayerCallback = callBack;
        this.webSocket.send(JSON.stringify(createCMSSignatureFromFile));
    }

    this.createCMSSignatureFromBase64 = function (storageName, keyType, base64ToSign, flag, callBack) {
        this.Initialize();
        var createCMSSignatureFromBase64 = {
            "module": "kz.gov.pki.knca.commonUtils",
            "method": "createCMSSignatureFromBase64",
            "args": [storageName, keyType, base64ToSign, flag]
        };
        ncaLayerCallback = callBack;
        this.webSocket.send(JSON.stringify(createCMSSignatureFromBase64));
    }
};