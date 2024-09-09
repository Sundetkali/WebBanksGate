Nat.Classes.NCALayer = function(vm, options) {

    if (!options.NCALayer && options.set)
        options.set('NCALayer', { storageSelect: 'PKCS12' });
    else if (!options.NCALayer)
        options.NCALayer = { storageSelect: 'PKCS12' };
    else if (!options.NCALayer.storageSelect && options.NCALayer.set)
        options.NCALayer.set('storageSelect', 'PKCS12');
    else if (!options.NCALayer.storageSelect)
        options.NCALayer.storageSelect = 'PKCS12';

    if (!vm.NCALayer) {
        vm.NCALayer = new Nat.Classes.NCALayerWebSocket();
        vm.NCALayer.Initialize();
    }

    var me = this;

    this.signXml = function (xmlToSign, done) {
        this.blockScreen();
        vm.NCALayer.signXml(this.options.NCALayer.storageSelect,
            "SIGNATURE",
            xmlToSign,
            function(result) {
                me.unblockScreen();

                if (result['code'] === "500") {
                    if (result['message'] !== 'action.canceled')
                        kendo.alert(result['message']);
                } else if (result['code'] === "200") {
                    var res = result['responseObject'];
                    done(res, result);
                }
            });
    }

    this.signArrayOfXml = function(xmlsToSign, done) {
        this.blockScreen();
        vm.NCALayer.signXmls(this.options.NCALayer.storageSelect, "SIGNATURE", xmlsToSign, function(result) {
            me.unblockScreen();
            if (result['code'] === "500") {
                if (result['message'] !== 'action.canceled')
                    kendo.alert(result['message']);
            } else if (result['code'] === "200") {
                var res = result['responseObject'];
                done(res, result);
            }
        });
    };

    this.createCMSSFromBase64 = function (base64ToSign, documentId, done) {
        this.blockScreen();
        vm.NCALayer.createCMSSignatureFromBase64(this.options.NCALayer.storageSelect,
            "SIGNATURE",
            base64ToSign,
            true, 
            function (result) {
                me.unblockScreen();

                if (result['code'] === "500") {
                    if (result['message'] !== 'action.canceled')
                        kendo.alert(result['message']);
                } else if (result['code'] === "200") {
                    var res = result['responseObject'];
                    done(res, result, documentId);
                }
            });
    }

    this.applyCAdESTBase64 = function (cmsForTs, done) {
        this.blockScreen();
        vm.NCALayer.applyCAdEST(this.options.NCALayer.storageSelect,
            "SIGNATURE",
            cmsForTs,
            function (result) {
                me.unblockScreen();
                if (result['code'] === "500") {
                    if (result['message'] !== 'action.canceled')
                        kendo.alert(result['message']);
                } else if (result['code'] === "200") {
                    var res = result['responseObject'];
                    done(res, result);
                }
            });
    }

    this.blockScreen = function() {
        kendo.ui.progress($(window.document.body), true);
    };
    
    this.unblockScreen = function() {
        kendo.ui.progress($(window.document.body), false);
    };
    
    this.changeLocale = function() {
        vm.NCALayer.changeLocale(window.currentCulture);
    };

    /*
     
    this.getActiveTokens = function() {
        this.this.blockScreen();
        this.getActiveTokens(function(result) {
            this.me.unblockScreen();
            if (result['code'] === "500") {
                kendo.alert(result['message']);
            } else if (result['code'] === "200") {
                var listOfTokens = result['responseObject'];
                $('#storageSelect').empty();
                $('#storageSelect').append('<option value="PKCS12">PKCS12</option>');
                for (var i = 0; i < listOfTokens.length; i++) {
                    $('#storageSelect')
                        .append('<option value="' + listOfTokens[i] + '">' + listOfTokens[i] + '</option>');
                }
            }
        });
    };

    this.getKeyInfo = function() {
        this.blockScreen();
        getKeyInfo(this.options.NCALayer.storageSelect,
            function(result) {
                me.unblockScreen();
                if (result['code'] === "500") {
                    alert(result['message']);
                } else if (result['code'] === "200") {
                    var res = result['responseObject'];

                    var alias = res['alias'];
                    $("#alias").val(alias);

                    var keyId = res['keyId'];
                    $("#keyId").val(keyId);

                    var algorithm = res['algorithm'];
                    $("#algorithm").val(algorithm);

                    var subjectCn = res['subjectCn'];
                    $("#subjectCn").val(subjectCn);

                    var subjectDn = res['subjectDn'];
                    $("#subjectDn").val(subjectDn);

                    var issuerCn = res['issuerCn'];
                    $("#issuerCn").val(issuerCn);

                    var issuerDn = res['issuerDn'];
                    $("#issuerDn").val(issuerDn);

                    var serialNumber = res['serialNumber'];
                    $("#serialNumber").val(serialNumber);

                    var dateString = res['certNotAfter'];
                    var date = new Date(Number(dateString));
                    $("#notafter").val(date.toLocaleString());

                    dateString = res['certNotBefore'];
                    date = new Date(Number(dateString));
                    $("#notbefore").val(date.toLocaleString());

                    var authorityKeyIdentifier = res['authorityKeyIdentifier'];
                    $("#authorityKeyIdentifier").val(authorityKeyIdentifier);

                    var pem = res['pem'];
                    $("#pem").val(pem);
                }
            });
    };

    this.createCAdESFromFile = function() {
        var selectedStorage = this.options.NCALayer.storageSelect;
        var flag = $("#flag").is(':checked');
        var filePath = $("#filePath").val();
        if (filePath !== null && filePath !== "") {
            this.blockScreen();
            createCAdESFromFile(selectedStorage,
                "SIGNATURE",
                filePath,
                flag,
                function(result) {
                    me.unblockScreen();
                    if (result['code'] === "500") {
                        kendo.alert(result['message']);
                    } else if (result['code'] === "200") {
                        var res = result['responseObject'];
                        $("#createdCMS").val(res);
                    }
                });
        } else {
            alert("Не выбран файл для подписи!");
        }
    };
    
    this.createCAdESFromBase64 = function () {
        var selectedStorage = this.options.NCALayer.storageSelect;
        var flag = $("#flagForBase64").is(':checked');
        var base64ToSign = $("#base64ToSign").val();
        if (base64ToSign !== null && base64ToSign !== "") {
            $.blockUI();
            createCAdESFromBase64(selectedStorage,
                "SIGNATURE",
                base64ToSign,
                flag,
                function(result) {
                    $.unblockUI();
                    if (result['code'] === "500") {
                        kendo.alert(result['message']);
                    } else if (result['code'] === "200") {
                        var res = result['responseObject'];
                        $("#createdCMSforBase64").val(res);
                    }
                });
        } else {
            alert("Нет данных для подписи!");
        }
    }

    this.createCAdESFromBase64Hash = function () {
        var selectedStorage = this.options.NCALayer.storageSelect;
        var base64ToSign = $("#base64HashToSign").val();
        if (base64ToSign !== null && base64ToSign !== "") {
            $.blockUI();
            createCAdESFromBase64Hash(selectedStorage, "SIGNATURE", base64ToSign, function (result) {
                $.unblockUI();
                if (result['code'] === "500") {
                    kendo.alert(result['message']);
                } else if (result['code'] === "200") {
                    var res = result['responseObject'];
                    $("#createdCMSforBase64Hash").val(res);
                }
            });
        } else {
            alert("Нет данных для подписи!");
        }
    }

    this.applyCAdEST = function () {
        var selectedStorage = this.options.NCALayer.storageSelect;
        var cmsForTS = $("#CMSForTS").val();
        if (cmsForTS !== null && cmsForTS !== "") {
            $.blockUI();
            applyCAdEST(selectedStorage, "SIGNATURE", cmsForTS, function (result) {
                $.unblockUI();
                if (result['code'] === "500") {
                    kendo.alert(result['message']);
                } else if (result['code'] === "200") {
                    var res = result['responseObject'];
                    $("#createdCMSWithAppliedTS").val(res);
                }
            });
        } else {
            alert("Нет данных для подписи!");
        }
    }

    this.showFileChooser = function () {
        this.blockScreen();
        showFileChooser("ALL", "", function (result) {
            me.unblockScreen();
            if (result['code'] === "500") {
                kendo.alert(result['message']);
            } else if (result['code'] === "200") {
                var res = result['responseObject'];
                $("#filePath").val(res);
            }
        });
    }

    this.showFileChooserForTS = function() {
        this.blockScreen();
        showFileChooser("ALL",
            "",
            function(result) {
                me.unblockScreen();
                if (result['code'] === "500") {
                    kendo.alert(result['message']);
                } else if (result['code'] === "200") {
                    var res = result['responseObject'];
                    $("#filePathWithTS").val(res);
                }
            });
    };

    this.createCMSSignatureFromFile = function() {
        var selectedStorage = this.options.NCALayer.storageSelect;
        var flag = $("#flagForCMSWithTS").is(':checked');
        var filePath = $("#filePathWithTS").val();
        if (filePath !== null && filePath !== "") {
            this.blockScreen();
            createCMSSignatureFromFile(selectedStorage,
                "SIGNATURE",
                filePath,
                flag,
                function(result) {
                    me.unblockScreen();
                    if (result['code'] === "500") {
                        kendo.alert(result['message']);
                    } else if (result['code'] === "200") {
                        var res = result['responseObject'];
                        $("#createdCMSWithTS").val(res);
                    }
                });
        } else {
            alert("Не выбран файл для подписи!");
        }
    };

    this.createCMSSignatureFromBase64 = function() {
        var selectedStorage = this.options.NCALayer.storageSelect;
        var flag = $("#flagForBase64WithTS").is(':checked');
        var base64ToSign = $("#base64ToSignWithTS").val();
        if (base64ToSign !== null && base64ToSign !== "") {
            $.blockUI();
            createCMSSignatureFromBase64(selectedStorage,
                "SIGNATURE",
                base64ToSign,
                flag,
                function(result) {
                    $.unblockUI();
                    if (result['code'] === "500") {
                        kendo.alert(result['message']);
                    } else if (result['code'] === "200") {
                        var res = result['responseObject'];
                        $("#createdCMSforBase64WithTS").val(res);
                    }
                });
        } else {
            alert("Нет данных для подписи!");
        }
    };*/
}