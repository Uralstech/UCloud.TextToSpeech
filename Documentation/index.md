---
_layout: landing
---

# UCloud.TextToSpeech

A Unity C# wrapper for the Google Cloud Text-To-Speech API.

[![openupm](https://img.shields.io/npm/v/com.uralstech.ucloud.texttospeech?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.uralstech.ucloud.texttospeech/)
[![openupm](https://img.shields.io/badge/dynamic/json?color=brightgreen&label=downloads&query=%24.downloads&suffix=%2Fmonth&url=https%3A%2F%2Fpackage.openupm.com%2Fdownloads%2Fpoint%2Flast-month%2Fcom.uralstech.ucloud.texttospeech)](https://openupm.com/packages/com.uralstech.ucloud.texttospeech/)

## Installation

This *should* work on any reasonably modern Unity version. Built and tested in Unity 6.0.

# [OpenUPM](#tab/openupm)

1. Open project settings
2. Select `Package Manager`
3. Add the OpenUPM package registry:
    - Name: `OpenUPM`
    - URL: `https://package.openupm.com`
    - Scope(s)
        - `com.uralstech`
4. Open the Unity Package Manager window (`Window` -> `Package Manager`)
5. Change the registry from `Unity` to `My Registries`
6. Add the `UCloud.TextToSpeech` package

# [Unity Package Manager](#tab/upm)

1. Open the Unity Package Manager window (`Window` -> `Package Manager`)
2. Select the `+` icon and `Add package from git URL...`
3. Paste the UPM branch URL and press enter:
    - `https://github.com/Uralstech/UCloud.TextToSpeech.git#upm`
4. Check the instructions for [`UCloud.Operations`](https://uralstech.github.io/UCloud.Operations) and [`Utils.Singleton`](https://uralstech.github.io/Utils.Singleton) to install the dependencies

# [GitHub Clone](#tab/github)

1. Clone or download the repository from the desired branch (master, preview/unstable)
2. Drag the package folder `UCloud.TextToSpeech/UCloud.TextToSpeech/Packages/com.uralstech.ucloud.texttospeech` into your Unity project's `Packages` folder
3. Check the instructions for [`UCloud.Operations`](https://uralstech.github.io/UCloud.Operations) and [`Utils.Singleton`](https://uralstech.github.io/Utils.Singleton) to install the dependencies

---

## Preview Versions

Do not use preview versions (i.e. versions that end with "-preview") for production use as they are unstable and untested.

## API Support

- ✔️ `operations` endpoint\*
    - ✔️ `cancel` method\*
    - ✔️ `delete` method\*

- ✔️ `projects.locations` endpoint
    - ❌ `synthesizeLongAudio` method
    - ✔️ `projects.locations.operations` endpoint\*
        - ✔️ `get` method\*
        - ✔️ `list` method\*

- ✔️ `text` endpoint
    - ✔️ `synthesize` method

- ✔️ `voices` endpoint
    - ✔️ `list` method

\*Through package dependency [UCloud.Operations](https://github.com/Uralstech/UCloud.Operations).

## Documentation

See <https://uralstech.github.io/UCloud.TextToSpeech/DocSource/QuickStart.html> or `APIReferenceManual.pdf` and `Documentation.pdf` in the package documentation for the reference manual and tutorial.
