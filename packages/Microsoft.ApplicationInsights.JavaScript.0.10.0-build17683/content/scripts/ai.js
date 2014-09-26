var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var Logging = (function () {
            function Logging() {
            }
            Logging.throwInternal = function (message) {
                if (Logging.enableDebugExceptions()) {
                    throw message;
                } else {
                    Logging.warn(message);
                }
            };

            Logging.warnInternal = function (message) {
                if (Logging.enableDebugExceptions()) {
                    Logging.warn(message);
                }
            };

            Logging.warn = function (message) {
                if (console && typeof console.warn === "function") {
                    console.warn(message);
                } else {
                    try  {
                        console.log(message);
                    } catch (e) {
                    }
                }
            };
            Logging.enableDebugExceptions = function () {
                return false;
            };
            return Logging;
        })();
        ApplicationInsights.Logging = Logging;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var Util = (function () {
            function Util() {
            }
            Util.setCookie = function (name, value) {
                Util.document.cookie = name + "=" + value;
            };

            Util.getCookie = function (name) {
                var value = "";
                if (name && name.length) {
                    var cookieName = name + "=";
                    var cookies = Util.document.cookie.split(';');
                    for (var i = 0; i < cookies.length; i++) {
                        var cookie = cookies[i];
                        cookie = Util.trim(cookie);
                        if (cookie && cookie.indexOf(cookieName) === 0) {
                            value = cookie.substring(cookieName.length, cookies[i].length);
                            break;
                        }
                    }
                }

                return value;
            };

            Util.trim = function (str) {
                return str.replace(/^\s+|\s+$/g, '');
            };

            Util.newGuid = function () {
                var hexValues = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"];

                var oct = "", tmp;
                for (var a = 0; a < 4; a++) {
                    tmp = (4294967296 * Math.random()) | 0;
                    oct += hexValues[tmp & 0xF] + hexValues[tmp >> 4 & 0xF] + hexValues[tmp >> 8 & 0xF] + hexValues[tmp >> 12 & 0xF] + hexValues[tmp >> 16 & 0xF] + hexValues[tmp >> 20 & 0xF] + hexValues[tmp >> 24 & 0xF] + hexValues[tmp >> 28 & 0xF];
                }

                var clockSequenceHi = hexValues[8 + (Math.random() * 4) | 0];
                return oct.substr(0, 8) + "-" + oct.substr(9, 4) + "-4" + oct.substr(13, 3) + "-" + clockSequenceHi + oct.substr(16, 3) + "-" + oct.substr(19, 12);
            };

            Util.isArray = function (obj) {
                return Object.prototype.toString.call(obj) === '[object Array]';
            };

            Util.toISOStringForIE8 = function (date) {
                if (Date.prototype.toISOString) {
                    return date.toISOString();
                } else {
                    function pad(number) {
                        var r = String(number);
                        if (r.length === 1) {
                            r = '0' + r;
                        }
                        return r;
                    }

                    return date.getUTCFullYear() + '-' + pad(date.getUTCMonth() + 1) + '-' + pad(date.getUTCDate()) + 'T' + pad(date.getUTCHours()) + ':' + pad(date.getUTCMinutes()) + ':' + pad(date.getUTCSeconds()) + '.' + String((date.getUTCMilliseconds() / 1000).toFixed(3)).slice(2, 5) + 'Z';
                }
            };

            Util.msToTimeSpan = function (totalms) {
                if (isNaN(totalms) || totalms < 0) {
                    totalms = 0;
                }

                var ms = "" + totalms % 1000;
                var sec = "" + Math.floor(totalms / 1000) % 60;
                var min = "" + Math.floor(totalms / (1000 * 60)) % 60;
                var hour = "" + Math.floor(totalms / (1000 * 60 * 60)) % 24;

                ms = ms.length === 1 ? "00" + ms : ms.length === 2 ? "0" + ms : ms;
                sec = sec.length < 2 ? "0" + sec : sec;
                min = min.length < 2 ? "0" + min : min;
                hour = hour.length < 2 ? "0" + hour : hour;

                return hour + ":" + min + ":" + sec + "." + ms;
            };
            Util.document = document;
            return Util;
        })();
        ApplicationInsights.Util = Util;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var Serializer = (function () {
            function Serializer() {
            }
            Serializer.serialize = function (input) {
                var output = Serializer.serializeObject(input, "root");
                return JSON.stringify(output);
            };

            Serializer.serializeObject = function (source, name) {
                var circularReferenceCheck = "__aiCircularRefCheck";
                var output = {};

                if (!source) {
                    ApplicationInsights.Logging.throwInternal("source is null");
                    return output;
                }

                if (source[circularReferenceCheck]) {
                    ApplicationInsights.Logging.throwInternal("Circular reference detected while serializing: '" + name);
                    return output;
                }

                if (!source.aiDataContract) {
                    if (name === "measurements") {
                        output = Serializer.serializeStringMap(source, "number", name);
                    } else if (name === "properties") {
                        output = Serializer.serializeStringMap(source, "string", name);
                    } else {
                        ApplicationInsights.Logging.warnInternal("Attempting to serialize an object which does not implement ISerializable: " + name);

                        try  {
                            JSON.stringify(source);
                            output = source;
                        } catch (e) {
                            ApplicationInsights.Logging.throwInternal(e && typeof e.toString === 'function' ? e.toString() : "Error serializing object");
                        }
                    }

                    return output;
                }

                source[circularReferenceCheck] = true;
                for (var field in source.aiDataContract) {
                    var isRequired = source.aiDataContract[field];
                    var isArray = typeof isRequired !== "boolean";
                    var isPresent = source[field] !== undefined;
                    var isObject = typeof source[field] === "object" && source[field] !== null;

                    if (isRequired && !isPresent) {
                        ApplicationInsights.Logging.throwInternal("Missing required field specification: The field '" + field + "' is required but not present on source");

                        continue;
                    }

                    var value;
                    if (isObject) {
                        if (isArray) {
                            value = Serializer.serializeArray(source[field], field);
                        } else {
                            value = Serializer.serializeObject(source[field], field);
                        }
                    } else {
                        value = source[field];
                    }

                    if (value !== undefined) {
                        output[field] = value;
                    }
                }

                delete source[circularReferenceCheck];
                return output;
            };

            Serializer.serializeArray = function (sources, name) {
                var output = undefined;

                if (!!sources) {
                    if (!ApplicationInsights.Util.isArray(sources)) {
                        ApplicationInsights.Logging.throwInternal("This field was specified as an array in the contract but the item is not an array.\r\n" + name);
                    } else {
                        output = [];
                        for (var i = 0; i < sources.length; i++) {
                            var source = sources[i];
                            var item = Serializer.serializeObject(source, name + "[" + i + "]");
                            output.push(item);
                        }
                    }
                }

                return output;
            };

            Serializer.serializeStringMap = function (map, expectedType, name) {
                var output = undefined;
                if (map) {
                    output = {};
                    for (var field in map) {
                        var value = map[field];
                        if (typeof value === expectedType) {
                            output[field] = value;
                        } else {
                            output[field] = "invalid field: " + name + ", the value must be of type:" + expectedType;
                            ApplicationInsights.Logging.warnInternal(output[field]);
                        }
                    }
                }

                return output;
            };
            return Serializer;
        })();
        ApplicationInsights.Serializer = Serializer;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var ApplicationContext = (function () {
            function ApplicationContext(appUserId) {
                this.aiDataContract = {
                    ver: false,
                    id: false
                };
                this.id = appUserId;
            }
            return ApplicationContext;
        })();
        ApplicationInsights.ApplicationContext = ApplicationContext;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var DeviceContext = (function () {
            function DeviceContext() {
                this.aiDataContract = {
                    type: false,
                    id: true,
                    os: true,
                    osVersion: true,
                    oemName: false,
                    model: false,
                    network: false,
                    resolution: false,
                    locale: true
                };
                this.id = "browser";

                this.type = "other";

                this.getOsInfo(navigator && navigator.appVersion);

                if (screen && screen.width && screen.height) {
                    this.resolution = screen.width + "X" + screen.height;
                }

                this.locale = (navigator && navigator.browserLanguage) ? navigator.browserLanguage : "unknown";
            }
            DeviceContext.prototype.getOsInfo = function (appVersion) {
                this.os = "unknown";
                this.osVersion = "unknown";
                var check = function (str) {
                    return appVersion.indexOf(str) !== -1;
                };
                if (appVersion) {
                    if (check("Win")) {
                        this.os = "Windows";
                        if (check("Windows NT 6.3")) {
                            this.osVersion = "8.1";
                        } else if (check("Windows NT 6.2")) {
                            this.osVersion = "8";
                        } else if (check("Windows NT 6.1")) {
                            this.osVersion = "7";
                        } else if (check("Windows NT 6.0")) {
                            this.osVersion = "Vista";
                        } else if (check("Windows NT 5.1")) {
                            this.osVersion = "XP";
                        } else if (check("Windows NT 5.0")) {
                            this.osVersion = "2000";
                        }
                    } else if (check("Mac")) {
                        this.os = "MacOS";
                        if (check("iPad") || check("iPhone") || check("iPod")) {
                            this.osVersion = "iOS";
                        } else {
                            this.osVersion = "OSX";
                        }
                    } else if (check("X11")) {
                        this.os = "UNIX";
                    } else if (check("Linux")) {
                        this.os = "Linux";
                        if (check("Android")) {
                            this.osVersion = "Android";
                        }
                    }
                }
            };
            return DeviceContext;
        })();
        ApplicationInsights.DeviceContext = DeviceContext;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var UserContext = (function () {
            function UserContext(accountId) {
                this.aiDataContract = {
                    id: true,
                    accountId: false
                };
                var cookie = ApplicationInsights.Util.getCookie('ai_user');
                if (cookie) {
                    var params = cookie.split("|");
                    if (params.length > 0) {
                        this.id = params[0];
                    }
                }

                if (!this.id) {
                    this.id = ApplicationInsights.Util.newGuid();
                    ApplicationInsights.Util.setCookie('ai_user', this.id);
                }

                this.accountId = accountId;
            }
            return UserContext;
        })();
        ApplicationInsights.UserContext = UserContext;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var SessionContext = (function () {
            function SessionContext() {
                this.aiDataContract = {
                    id: true
                };
                var cookie = ApplicationInsights.Util.getCookie('ai_session');
                if (cookie && typeof cookie.split === "function") {
                    var params = cookie.split("|");
                    if (params.length > 0) {
                        this.id = params[0];
                    }

                    if (params.length > 1) {
                        var acq = params[1];
                        this.acquisitionDate = +new Date(acq);
                        this.acquisitionDate = this.acquisitionDate > 0 ? this.acquisitionDate : 0;
                    }

                    if (params.length > 1) {
                        var renewal = params[1];
                        this.renewalDate = +new Date(renewal);
                        this.renewalDate = this.renewalDate > 0 ? this.renewalDate : 0;
                    }
                }

                if (!this.id) {
                    this.renew();
                }
            }
            SessionContext.prototype.update = function () {
                var now = +new Date;

                var acquisitionExpired = now - this.acquisitionDate > SessionContext.acquisitionSpan;
                var renewalExpired = now - this.renewalDate > SessionContext.renewalSpan;

                if (acquisitionExpired || renewalExpired) {
                    this.renew();
                } else {
                    this.renewalDate = +new Date;
                    this.setCookie(this.id, this.acquisitionDate, this.renewalDate);
                }
            };

            SessionContext.prototype.renew = function () {
                this.id = ApplicationInsights.Util.newGuid();
                var now = +new Date;
                this.acquisitionDate = now;
                this.renewalDate = now;
                this.setCookie(this.id, this.acquisitionDate, this.renewalDate);
            };

            SessionContext.prototype.setCookie = function (guid, acq, renewal) {
                var acqStr = ApplicationInsights.Util.toISOStringForIE8(new Date(acq));
                var renewalStr = ApplicationInsights.Util.toISOStringForIE8(new Date(renewal));
                var cookie = [guid, acqStr, renewalStr];
                ApplicationInsights.Util.setCookie('ai_session', cookie.join('|'));
            };
            SessionContext.acquisitionSpan = 24 * 60 * 60 * 1000;
            SessionContext.renewalSpan = 30 * 60 * 1000;
            return SessionContext;
        })();
        ApplicationInsights.SessionContext = SessionContext;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var LocationContext = (function () {
            function LocationContext() {
                this.aiDataContract = {
                    Latitude: false,
                    Longitude: false,
                    IP: false,
                    Continent: false,
                    Country: false,
                    Province: false,
                    City: false
                };
            }
            return LocationContext;
        })();
        ApplicationInsights.LocationContext = LocationContext;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var OperationContext = (function () {
            function OperationContext() {
                this.aiDataContract = {
                    id: true
                };
                this.id = ApplicationInsights.Util.newGuid();
            }
            return OperationContext;
        })();
        ApplicationInsights.OperationContext = OperationContext;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var TelemetryBase = (function () {
            function TelemetryBase(name, data) {
                this.ver = 1;
                this.name = name;
                this.data = data;
                this.time = ApplicationInsights.Util.toISOStringForIE8(new Date());

                var contract = {
                    ver: true,
                    name: true,
                    time: true,
                    iKey: true,
                    device: false,
                    application: false,
                    user: false,
                    operation: false,
                    location: false,
                    session: false,
                    data: true
                };

                this.aiDataContract = contract;
            }
            return TelemetryBase;
        })();
        ApplicationInsights.TelemetryBase = TelemetryBase;

        var TelemetryData = (function () {
            function TelemetryData(name, item) {
                this.aiDataContract = {
                    name: true,
                    item: true
                };
                this.name = name;
                this.item = item;
            }
            return TelemetryData;
        })();
        ApplicationInsights.TelemetryData = TelemetryData;

        var TelemetryItem = (function () {
            function TelemetryItem(contractExtension, properties, measurements) {
                this.ver = 1.0;
                this.properties = properties;
                this.measurements = measurements;

                var contract = {
                    ver: true,
                    measurements: false,
                    properties: false
                };

                this.aiDataContract = TelemetryItem.extendContract(contract, contractExtension);
            }
            TelemetryItem.extendContract = function (contract, contractExtension) {
                if (!contract) {
                    if (contractExtension) {
                        contract = {};
                    }
                }

                for (var field in contractExtension) {
                    contract[field] = contractExtension[field];
                }

                return contract;
            };
            return TelemetryItem;
        })();
        ApplicationInsights.TelemetryItem = TelemetryItem;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var Sender = (function () {
            function Sender(config) {
                this.buffer = [];
                this.lastSend = 0;
                this.config = config;
                this.sender = null;
                if (typeof XMLHttpRequest != "undefined") {
                    var testXhr = new XMLHttpRequest();
                    if ("withCredentials" in testXhr) {
                        this.sender = this.xhrSender;
                    } else if (typeof XDomainRequest !== "undefined") {
                        this.sender = this.xdrSender;
                    }
                }
            }
            Sender.prototype.send = function (telemetry) {
                var _this = this;
                if (!telemetry) {
                    ApplicationInsights.Logging.throwInternal("Cannot send empty telemetry");
                    return;
                }

                if (!this.sender) {
                    ApplicationInsights.Logging.throwInternal("No sender could be constructed for this environment, payload will be added to buffer." + ApplicationInsights.Serializer.serialize(telemetry));
                    return;
                }

                var payload = ApplicationInsights.Serializer.serialize(telemetry);
                if (payload.length > this.config.maxPayloadSizeInBytes()) {
                    telemetry = this.truncate(telemetry, payload.length);
                    payload = ApplicationInsights.Serializer.serialize(telemetry);
                }

                if (this.getSizeInBytes(this.buffer) + payload.length > this.config.maxPayloadSizeInBytes()) {
                    this.triggerSend();
                }

                this.buffer.push(payload);

                if (!this.timeoutHandle) {
                    this.timeoutHandle = setTimeout(function () {
                        _this.timeoutHandle = null;
                        _this.triggerSend();
                    }, this.config.bufferMaxInterval());
                }
            };

            Sender.prototype.getSizeInBytes = function (list) {
                var size = 0;
                if (list && list.length) {
                    for (var i = 0; i < list.length; i++) {
                        var item = list[i];
                        if (item && item.length) {
                            size += item.length;
                        }
                    }
                }

                return size;
            };

            Sender.prototype.truncate = function (telemetry, initialSize) {
                if (telemetry && telemetry.data && telemetry.data.item) {
                    var maxSize = this.config.maxPayloadSizeInBytes();
                    telemetry.data.item.properties = { Error: "optional fields truncated because they exceeded: " + maxSize + " bytes" };
                    delete telemetry.data.item.measurements;
                }

                return telemetry;
            };

            Sender.prototype.triggerSend = function () {
                if (this.buffer.length) {
                    var batch = "[" + this.buffer.join(",") + "]";

                    this.sender(batch);
                }

                this.buffer.length = 0;
                clearTimeout(this.timeoutHandle);
                this.timeoutHandle = null;

                this.lastSend = +new Date;
            };

            Sender.prototype.xhrSender = function (payload) {
                var xhr = new XMLHttpRequest();
                xhr.open("POST", this.config.endpointUrl(), true);
                xhr.setRequestHeader("Content-type", "application/json");
                xhr.onreadystatechange = function () {
                    return Sender.xhrReadyStateChange(xhr, payload);
                };
                xhr.onerror = function (event) {
                    return Sender.onError(payload, event);
                };
                xhr.send(payload);
            };

            Sender.prototype.xdrSender = function (payload) {
                var xdr = new XDomainRequest();
                xdr.onload = function () {
                    return Sender.xdrOnLoad(xdr, payload);
                };
                xdr.onerror = function (event) {
                    return Sender.onError(payload, event);
                };
                xdr.open('POST', this.config.endpointUrl());
                xdr.send(payload);
            };

            Sender.xhrReadyStateChange = function (xhr, payload) {
                if (xhr.readyState === 4) {
                    if ((xhr.status < 200 || xhr.status >= 300) && xhr.status !== 0) {
                        Sender.onError(payload);
                    } else {
                        Sender.onSuccess(payload);
                    }
                }
            };

            Sender.xdrOnLoad = function (xdr, payload) {
                if (xdr && xdr.responseText + "" === "200") {
                    Sender.onSuccess(payload);
                } else {
                    Sender.onError(payload);
                }
            };

            Sender.onError = function (payload, event) {
                ApplicationInsights.Logging.throwInternal("Failed to send telemetry: " + payload);
            };

            Sender.onSuccess = function (payload) {
            };
            return Sender;
        })();
        ApplicationInsights.Sender = Sender;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var TraceTelemetry = (function (_super) {
            __extends(TraceTelemetry, _super);
            function TraceTelemetry(message, properties, measurements) {
                var data = new ApplicationInsights.TelemetryData("Microsoft.ApplicationInsights.MessageData", (new MessageData(message, properties, measurements)));
                _super.call(this, TraceTelemetry.type, data);
            }
            TraceTelemetry.type = "Microsoft.ApplicationInsights.Message";
            return TraceTelemetry;
        })(ApplicationInsights.TelemetryBase);
        ApplicationInsights.TraceTelemetry = TraceTelemetry;

        var MessageData = (function () {
            function MessageData(message, properties, measurements) {
                this.aiDataContract = {
                    ver: true,
                    message: true,
                    measurements: false,
                    properties: false
                };
                this.ver = 1;
                this.message = message;
                this.properties = properties;
                this.measurements = measurements;
            }
            return MessageData;
        })();
        ApplicationInsights.MessageData = MessageData;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var AjaxCallTelemetry = (function (_super) {
            __extends(AjaxCallTelemetry, _super);
            function AjaxCallTelemetry() {
                var data = new ApplicationInsights.TelemetryData("Microsoft.ApplicationInsights.AJAXCallData", new AJAXCallData());

                _super.call(this, AjaxCallTelemetry.type, data);
            }
            AjaxCallTelemetry.type = "Microsoft.ApplicationInsights.AJAXCall";
            return AjaxCallTelemetry;
        })(ApplicationInsights.TelemetryBase);
        ApplicationInsights.AjaxCallTelemetry = AjaxCallTelemetry;

        var AJAXCallData = (function () {
            function AJAXCallData() {
                this.ver = 1;
                this.name = "";
                this.url = "";
                this.duration = "";
                this.ajaxURL = "";
                this.requestSize = "";
                this.responseSize = "";
                this.timeToFIrstByte = "";
                this.timetoLastByte = "";
                this.callbackDuration = "";
                this.reponseCode = "";
                this.success = true;
                this.aiDataContract = {
                    ver: true,
                    name: true,
                    url: true,
                    duration: true,
                    ajaxURL: true,
                    requestSize: true,
                    responseSize: true,
                    timeToFIrstByte: true,
                    timetoLastByte: true,
                    callbackDuration: true,
                    reponseCode: true,
                    success: true,
                    measurements: false,
                    properties: false
                };
            }
            return AJAXCallData;
        })();
        ApplicationInsights.AJAXCallData = AJAXCallData;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var EventTelemetry = (function (_super) {
            __extends(EventTelemetry, _super);
            function EventTelemetry(name, properties, measurements) {
                var item = new EventData(name, properties, measurements);
                var data = new ApplicationInsights.TelemetryData("Microsoft.ApplicationInsights.EventData", item);
                _super.call(this, EventTelemetry.type, data);
            }
            EventTelemetry.type = "Microsoft.ApplicationInsights.Event";
            return EventTelemetry;
        })(ApplicationInsights.TelemetryBase);
        ApplicationInsights.EventTelemetry = EventTelemetry;

        var EventData = (function (_super) {
            __extends(EventData, _super);
            function EventData(eventName, properties, measurements) {
                var contract = {
                    name: false
                };

                _super.call(this, contract, properties, measurements);
                this.name = eventName;
            }
            return EventData;
        })(ApplicationInsights.TelemetryItem);
        ApplicationInsights.EventData = EventData;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var ExceptionTelemetry = (function (_super) {
            __extends(ExceptionTelemetry, _super);
            function ExceptionTelemetry(exceptions, properties, measurements) {
                var data = new ApplicationInsights.TelemetryData("Microsoft.ApplicationInsights.ExceptionData", new ExceptionData([], exceptions, properties, measurements));
                _super.call(this, ExceptionTelemetry.type, data);
            }
            ExceptionTelemetry.type = "Microsoft.ApplicationInsights.Exception";
            return ExceptionTelemetry;
        })(ApplicationInsights.TelemetryBase);
        ApplicationInsights.ExceptionTelemetry = ExceptionTelemetry;

        var ExceptionData = (function (_super) {
            __extends(ExceptionData, _super);
            function ExceptionData(exceptions, rawExceptions, properties, measurements) {
                var contract = {
                    handledAt: true,
                    exceptions: []
                };

                _super.call(this, contract, properties, measurements);
                this.handledAt = "";
                for (var i = 0; i < rawExceptions.length; i++) {
                    exceptions.push(new ExceptionDataExceptions(rawExceptions[i]));
                }
                this.exceptions = exceptions;
            }
            return ExceptionData;
        })(ApplicationInsights.TelemetryItem);
        ApplicationInsights.ExceptionData = ExceptionData;

        var ExceptionDataExceptions = (function () {
            function ExceptionDataExceptions(exception) {
                this.aiDataContract = {
                    typeName: true,
                    message: true,
                    hasFullStack: false,
                    stack: false,
                    parsedStack: []
                };
                this.typeName = exception.name;
                this.message = exception.message;
                var rawStack = exception.stack;
                var parsedStack = this.parseStack(rawStack);
                if (parsedStack != []) {
                    this.parsedStack = parsedStack;
                } else {
                    this.stack = rawStack ? rawStack.toString() : "";
                }
            }
            ExceptionDataExceptions.prototype.parseStack = function (stack) {
                var parsedStack = [];
                if (stack) {
                    frames = stack.split('\n');
                    for (var i = 1; i < frames.length; i++) {
                        parsedStack.push(new ExceptionStackFrame(frames[i], i - 1));
                    }
                }
                return parsedStack;
            };
            return ExceptionDataExceptions;
        })();
        ApplicationInsights.ExceptionDataExceptions = ExceptionDataExceptions;

        var ExceptionStackFrame = (function () {
            function ExceptionStackFrame(frame, level) {
                this.method = "";
                this.aiDataContract = {
                    level: false,
                    method: true,
                    assembly: false,
                    line: false
                };
                this.level = level;
                var splitFrame = frame.split(':');
                if (splitFrame[splitFrame.length - 2]) {
                    this.line = parseInt(splitFrame[splitFrame.length - 2]);
                }
                if (frame.indexOf('at') > -1 && frame.indexOf(' ', frame.indexOf('at') + 3) > -1) {
                    this.method = frame.substring(frame.indexOf('at') + 3, frame.indexOf(' ', frame.indexOf('at') + 3));
                }
                if (frame.indexOf('file') > -1 && frame.indexOf('.js') > -1) {
                    this.assembly = frame.substring(frame.indexOf('file:'), frame.indexOf('.js') + 3);
                }
            }
            return ExceptionStackFrame;
        })();
        ApplicationInsights.ExceptionStackFrame = ExceptionStackFrame;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var MetricTelemetry = (function (_super) {
            __extends(MetricTelemetry, _super);
            function MetricTelemetry(metricData) {
                var data = new ApplicationInsights.TelemetryData("Microsoft.ApplicationInsights.MetricData", metricData);
                _super.call(this, MetricTelemetry.type, data);
            }
            MetricTelemetry.type = "Microsoft.ApplicationInsights.Metric";
            return MetricTelemetry;
        })(ApplicationInsights.TelemetryBase);
        ApplicationInsights.MetricTelemetry = MetricTelemetry;

        var MetricData = (function (_super) {
            __extends(MetricData, _super);
            function MetricData(name, value, type, count, min, max, properties, measurements) {
                var contract = {
                    metrics: []
                };

                _super.call(this, contract, properties, measurements);
                this.metrics = [new MetricDatum(name, value, type, count, min, max)];
            }
            return MetricData;
        })(ApplicationInsights.TelemetryItem);
        ApplicationInsights.MetricData = MetricData;

        var MetricDatum = (function () {
            function MetricDatum(name, value, type, count, min, max) {
                this.aiDataContract = {
                    name: true,
                    value: true,
                    type: false,
                    count: false,
                    min: false,
                    max: false
                };
                this.name = name;
                this.value = value;
                if (!type) {
                    type = "M";
                }
                if (type !== "M" && type !== "A") {
                    ApplicationInsights.Logging.throwInternal("Invalid type specified '" + type + "', only 'M' or 'A' are allowed. Defaulting to 'M' for single metrics");
                    type = "M";
                }

                this.type = type;
                this.count = count > 0 ? count : undefined;
                this.min = isNaN(min) || min === null ? undefined : min;
                this.max = isNaN(max) || max === null ? undefined : max;
            }
            return MetricDatum;
        })();
        ApplicationInsights.MetricDatum = MetricDatum;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var PageViewTelemetry = (function (_super) {
            __extends(PageViewTelemetry, _super);
            function PageViewTelemetry(duration, url, properties, measurements) {
                var data = new ApplicationInsights.TelemetryData("Microsoft.ApplicationInsights.PageviewData", new PageviewData(duration, url, properties, measurements));
                _super.call(this, PageViewTelemetry.type, data);
            }
            PageViewTelemetry.type = "Microsoft.ApplicationInsights.Pageview";
            return PageViewTelemetry;
        })(ApplicationInsights.TelemetryBase);
        ApplicationInsights.PageViewTelemetry = PageViewTelemetry;

        var PageviewData = (function (_super) {
            __extends(PageviewData, _super);
            function PageviewData(duration, url, properties, measurements) {
                var contract = {
                    name: false,
                    url: false,
                    duration: true
                };

                _super.call(this, contract, properties, measurements);

                this.url = url || window.location && window.location.href || "";
                this.name = window.document && window.document.title || "";
                this.duration = ApplicationInsights.Util.msToTimeSpan(duration);
            }
            return PageviewData;
        })(ApplicationInsights.TelemetryItem);
        ApplicationInsights.PageviewData = PageviewData;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var PageViewPerformanceTelemetry = (function (_super) {
            __extends(PageViewPerformanceTelemetry, _super);
            function PageViewPerformanceTelemetry(duration, url, properties, measurements) {
                var data = new ApplicationInsights.TelemetryData("Microsoft.ApplicationInsights.PageViewPerformanceData", new PageViewPerformanceData(duration, url, properties, measurements));
                _super.call(this, PageViewPerformanceTelemetry.type, data);
            }
            PageViewPerformanceTelemetry.type = "Microsoft.ApplicationInsights.PageviewPerformance";
            return PageViewPerformanceTelemetry;
        })(ApplicationInsights.TelemetryBase);
        ApplicationInsights.PageViewPerformanceTelemetry = PageViewPerformanceTelemetry;

        var PageViewPerformanceData = (function (_super) {
            __extends(PageViewPerformanceData, _super);
            function PageViewPerformanceData(duration, url, properties, measurements) {
                _super.call(this, duration, url, properties, measurements);

                var contractExtension = {
                    perfTotal: false,
                    networkConnect: false,
                    sentRequest: false,
                    receivedResponse: false,
                    domProcessing: false
                };

                this.aiDataContract = ApplicationInsights.TelemetryItem.extendContract(this.aiDataContract, contractExtension);
                if (typeof window != "undefined" && window.performance && window.performance.timing) {
                    this.perfTotal = PageViewPerformanceData.getSpan(window.performance.timing.domainLookupStart, window.performance.timing.loadEventEnd);
                    this.networkConnect = PageViewPerformanceData.getSpan(window.performance.timing.navigationStart, window.performance.timing.connectEnd);
                    this.sentRequest = PageViewPerformanceData.getSpan(window.performance.timing.requestStart, window.performance.timing.responseStart);
                    this.receivedResponse = PageViewPerformanceData.getSpan(window.performance.timing.responseStart, window.performance.timing.responseEnd);
                    this.domProcessing = PageViewPerformanceData.getSpan(window.performance.timing.domLoading, window.performance.timing.loadEventEnd);
                }
            }
            PageViewPerformanceData.checkPageLoad = function () {
                var status = undefined;
                if (typeof window != "undefined" && window.performance && window.performance.timing) {
                    status = window.performance.timing.domainLookupStart > 0 && window.performance.timing.navigationStart > 0 && window.performance.timing.responseStart > 0 && window.performance.timing.requestStart > 0 && window.performance.timing.loadEventEnd > 0 && window.performance.timing.responseEnd > 0 && window.performance.timing.connectEnd > 0 && window.performance.timing.domLoading > 0;
                }

                return status;
            };

            PageViewPerformanceData.getSpan = function (start, end) {
                var duration = PageViewPerformanceData.getDuration(start, end);
                return ApplicationInsights.Util.msToTimeSpan(duration);
            };

            PageViewPerformanceData.getDuration = function (start, end) {
                var duration = 0;
                if (!(isNaN(start) || isNaN(end) || start === 0 || end === 0)) {
                    duration = Math.max(end - start, 0);
                }

                return duration;
            };
            return PageViewPerformanceData;
        })(ApplicationInsights.PageviewData);
        ApplicationInsights.PageViewPerformanceData = PageViewPerformanceData;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var RemoteDependencyTelemetry = (function (_super) {
            __extends(RemoteDependencyTelemetry, _super);
            function RemoteDependencyTelemetry(dependencyKind, resource, name, value, type, count, min, max) {
                var data = new ApplicationInsights.TelemetryData("Microsoft.ApplicationInsights.RemoteDependencyData", new RemoteDependencyData(dependencyKind, resource, name, value, type, count, min, max));

                _super.call(this, RemoteDependencyTelemetry.type, data);
            }
            RemoteDependencyTelemetry.type = "Microsoft.ApplicationInsights.RemoteDependency";
            return RemoteDependencyTelemetry;
        })(ApplicationInsights.TelemetryBase);
        ApplicationInsights.RemoteDependencyTelemetry = RemoteDependencyTelemetry;

        var RemoteDependencyData = (function (_super) {
            __extends(RemoteDependencyData, _super);
            function RemoteDependencyData(dependencyKind, resource, name, value, type, count, min, max) {
                _super.call(this, name, value, type, count, min, max);

                this.ver = 1;
                this.dependencyKind = dependencyKind;
                this.resource = resource;

                var contractExtension = {
                    ver: true,
                    dependencyKind: false,
                    resource: true,
                    measurements: false,
                    properties: false
                };

                this.aiDataContract = ApplicationInsights.TelemetryItem.extendContract(this.aiDataContract, contractExtension);
            }
            return RemoteDependencyData;
        })(ApplicationInsights.MetricDatum);
        ApplicationInsights.RemoteDependencyData = RemoteDependencyData;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var RequestTelemetry = (function (_super) {
            __extends(RequestTelemetry, _super);
            function RequestTelemetry() {
                var data = new ApplicationInsights.TelemetryData("Microsoft.ApplicationInsights.RequestData", new RequestData());

                _super.call(this, RequestTelemetry.type, data);
            }
            RequestTelemetry.type = "Microsoft.ApplicationInsights.Request";
            return RequestTelemetry;
        })(ApplicationInsights.TelemetryBase);
        ApplicationInsights.RequestTelemetry = RequestTelemetry;

        var RequestData = (function () {
            function RequestData() {
                this.ver = 1;
                this.name = "";
                this.aiDataContract = {
                    ver: true,
                    name: true,
                    id: false,
                    startTime: false,
                    duration: false,
                    responseCode: false,
                    success: false,
                    measurements: false,
                    properties: false
                };
            }
            return RequestData;
        })();
        ApplicationInsights.RequestData = RequestData;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var TelemetryContext = (function () {
            function TelemetryContext(config) {
                this.config = config;
                this.sender = new ApplicationInsights.Sender(config);
                if (typeof window !== 'undefined') {
                    this.device = new ApplicationInsights.DeviceContext();
                    this.application = config.appUserId() && new ApplicationInsights.ApplicationContext(config.appUserId());
                    this.user = new ApplicationInsights.UserContext(config.accountId());
                    this.operation = new ApplicationInsights.OperationContext();
                    this.session = new ApplicationInsights.SessionContext();
                }
            }
            TelemetryContext.prototype.track = function (telemetryObject) {
                if (!telemetryObject) {
                    ApplicationInsights.Logging.throwInternal("Telemetry is null");
                } else {
                    telemetryObject.iKey = telemetryObject.iKey || this.config.iKey();
                    telemetryObject.device = telemetryObject.device || this.device;
                    telemetryObject.user = telemetryObject.user || this.user;
                    telemetryObject.session = telemetryObject.session || this.session;
                    telemetryObject.application = telemetryObject.application || this.application;
                    telemetryObject.operation = telemetryObject.operation || this.operation;
                    telemetryObject.location = telemetryObject.location || this.location;

                    if (telemetryObject.session && typeof telemetryObject.session.update === "function") {
                        telemetryObject.session.update();
                    }

                    if (telemetryObject.data && telemetryObject.data.item) {
                        telemetryObject.data.item.properties = TelemetryContext.instrumentTelemetryProperties(telemetryObject.data.item.properties);
                    }

                    this.sender.send(telemetryObject);
                }

                return telemetryObject;
            };

            TelemetryContext.instrumentTelemetryProperties = function (properties, version) {
                properties = properties || {};
                properties["SDKVersion"] = properties["SDKVersion"] || version || "0.10.0.0";
                return properties;
            };
            return TelemetryContext;
        })();
        ApplicationInsights.TelemetryContext = TelemetryContext;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var AppInsights = (function () {
            function AppInsights(prefix) {
                ApplicationInsights.Logging.enableDebugExceptions = function () {
                    return prefix.enableDebug;
                };
                var config = {
                    iKey: function () {
                        return prefix.iKey;
                    },
                    accountId: function () {
                        return prefix.accountId;
                    },
                    appUserId: function () {
                        return prefix.appUserId;
                    },
                    endpointUrl: function () {
                        return prefix.endpointUrl;
                    },
                    maxPayloadSizeInBytes: function () {
                        return prefix.maxPayloadSizeInBytes;
                    },
                    bufferMinInterval: function () {
                        return prefix.bufferMinInterval;
                    },
                    bufferMaxInterval: function () {
                        return prefix.bufferMaxInterval;
                    }
                };

                this.context = new Microsoft.ApplicationInsights.TelemetryContext(config);
            }
            AppInsights.prototype.trackPageView = function (pagePath, properties, measurements) {
                var _this = this;
                var duration = 0;
                if (ApplicationInsights.PageViewPerformanceData.checkPageLoad() !== undefined) {
                    var startTime = window.performance.timing.navigationStart;
                    duration = ApplicationInsights.PageViewPerformanceData.getDuration(startTime, +new Date);

                    var handle = setInterval(function () {
                        duration = ApplicationInsights.PageViewPerformanceData.getDuration(+new Date, startTime);
                        var timingDataReady = ApplicationInsights.PageViewPerformanceData.checkPageLoad();
                        var timeoutReached = duration > 60000;
                        if (timeoutReached || timingDataReady) {
                            clearInterval(handle);
                            duration = ApplicationInsights.PageViewPerformanceData.getDuration(startTime, +new Date);
                            _this.context.track(new ApplicationInsights.PageViewPerformanceTelemetry(duration, pagePath, properties, measurements));
                            _this.context.sender.triggerSend();
                        }
                    }, 100);
                }

                this.context.track(new ApplicationInsights.PageViewTelemetry(duration, pagePath, properties, measurements));
                setTimeout(function () {
                    _this.context.sender.triggerSend();
                }, 100);
            };

            AppInsights.prototype.trackEvent = function (name, properties, measurements) {
                this.context.track(new ApplicationInsights.EventTelemetry(name, properties, measurements));
            };

            AppInsights.prototype.trackException = function (exception, properties, measurements) {
                if (ApplicationInsights.Util.isArray(exception)) {
                    var exceptions = exception;
                    this.context.track(new ApplicationInsights.ExceptionTelemetry(exceptions, properties, measurements));
                } else {
                    this.context.track(new ApplicationInsights.ExceptionTelemetry([exception], properties, measurements));
                }
            };

            AppInsights.prototype.trackMetric = function (name, value, type, count, min, max, properties, measurements) {
                var _this = this;
                if (this.batchedMetrics) {
                    var datum = new ApplicationInsights.MetricDatum(name, value, type, count, min, max);
                    this.batchedMetrics.metrics.push(datum);
                } else {
                    this.batchedMetrics = new ApplicationInsights.MetricData(name, value, type, count, min, max, properties, measurements);
                    setTimeout(function () {
                        _this.context.track(new ApplicationInsights.MetricTelemetry(_this.batchedMetrics));
                        _this.batchedMetrics = null;
                    }, 1);
                }
            };

            AppInsights.prototype.trackTrace = function (message, properties, measurements) {
                this.context.track(new ApplicationInsights.TraceTelemetry(message, properties, measurements));
            };

            AppInsights.prototype.logPageView = function (pagePath, properties, measurements) {
                properties = ApplicationInsights.TelemetryContext.instrumentTelemetryProperties(properties, "0.7.2.0");
                this.trackPageView(pagePath, properties, measurements);
            };

            AppInsights.prototype.logEvent = function (name, properties, measurements) {
                properties = ApplicationInsights.TelemetryContext.instrumentTelemetryProperties(properties, "0.7.2.0");
                this.trackEvent(name, properties, measurements);
            };
            return AppInsights;
        })();
        ApplicationInsights.AppInsights = AppInsights;
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    (function (ApplicationInsights) {
        var prefix;
        prefix = {};
        if (typeof window !== "undefined") {
            prefix = window["appInsights"];
        }

        if (!prefix.iKey) {
            if (prefix["applicationInsightsId"]) {
                prefix.iKey = prefix["applicationInsightsId"];
            } else {
                throw new Error("Cannot load Application Insights SDK, no instrumentation key (iKey) was provided.");
            }
        }

        prefix.iKey = prefix.iKey;
        prefix.queue = prefix.queue ? prefix.queue : [];
        prefix.endpointUrl = prefix.endpointUrl || "//dc.services.visualstudio.com/v2/track";
        prefix.accountId = prefix.accountId;
        prefix.appUserId = prefix.appUserId;
        prefix.maxPayloadSizeInBytes = prefix.maxPayloadSizeInBytes > 0 ? prefix.maxPayloadSizeInBytes : 900000;
        prefix.bufferMinInterval = !isNaN(prefix.bufferMinInterval) ? prefix.bufferMinInterval : 0;
        prefix.bufferMaxInterval = !isNaN(prefix.bufferMaxInterval) ? prefix.bufferMaxInterval : 15000;
        prefix.enableDebug = !!prefix.enableDebug;

        if (typeof JSON !== "undefined") {
            var appInsights = new ApplicationInsights.AppInsights(prefix);
            for (var field in appInsights) {
                prefix[field] = appInsights[field];
            }

            try  {
                if (Microsoft.ApplicationInsights.Util.isArray(prefix.queue)) {
                    var length = prefix.queue.length;
                    for (var i = 0; i < length; i++) {
                        var call = prefix.queue[i];
                        call();
                    }

                    prefix.queue.length = 0;
                }
            } catch (exception) {
                var message = "Failed to send queued telemetry";
                if (exception && typeof exception.toString === "function") {
                    message += ": " + exception.toString();
                }

                Microsoft.ApplicationInsights.Logging.throwInternal(message);
            }
        } else {
            ApplicationInsights.Logging.throwInternal("Cannot load Application Insights SDK from this environment, aborting initialization");
        }
    })(Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
    var ApplicationInsights = Microsoft.ApplicationInsights;
})(Microsoft || (Microsoft = {}));
