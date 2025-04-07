import { dotnet } from './_framework/dotnet.js'

const is_browser = typeof window != "undefined";
if (!is_browser) throw new Error(`Expected to be running in a browser`);

const dotnetRuntime = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

const config = dotnetRuntime.getConfig();

globalThis.saveFileToIndexedDB = async function (filename, content) {
    localStorage.setItem(filename, content);
};

globalThis.loadFileFromIndexedDB = async function (filename) {
    return localStorage.getItem(filename);
};

globalThis.isFileSystemAccessSupported = async function () {
    return 'showOpenFilePicker' in window && 'showSaveFilePicker' in window && 'showDirectoryPicker' in window;
};

await dotnetRuntime.runMain(config.mainAssemblyName, [globalThis.location.href]);
