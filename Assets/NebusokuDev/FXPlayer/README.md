# FXPlayer For Unity

[//]: # (image or gif)

## Overview

FxPlayerForUnityはCRI ADX2と同様の`CueName`を指定する方法で音声、パーティクルエフェクトを再生するためのライブラリです。

FXPlayerを使用することで
- `IFxPlayer`インターフェースを使ったエフェクトと音声の同時再生
- `ISoundPlayer`を実装することで、ADX2,Wwise,FMODなどのサウンドエンジンへの乗り換えが容易
- `Cue`をまとめた`CueSheet`単位での再生の管理と`CueName`で呼び出しの一元化
- パーティクルエフェクトの再利用
などが出来ます。

## Requirement

FxPlayerを使用するためには、以下の環境が必須になります。

- Unity 2020 LTS Later

## Install

### git urlを使う

git urlを利用してインストールすることができます。 インストールする場合は、 パッケージマネージャの`Add package from git URL...`に以下のurlを入力してください。

```text
https://github.com/NebusokuDev/Smith.git?path=Assets/NebusokuDev/FXPlayer
```

### OpenUPMを使う

OpenUPMを利用して、インストールすることが出来ます。OpenUPMレジストリを`Project Settings/ScopedRegistry`に登録し、以下のパッケージを登録します。

`openupm-cli`を使用する場合は、以下のコマンドラインをプロジェクトディレクトリ配下で入力します。

```text
openupm add com.nebusokudev.fxplayer
```

## Usage

### UnitySoundPlayer
UnitySoundPlayerはUnityビルトインのサウンド再生機能である`AudioSource`、`AudioClip`、`AudioMixerGroup`を使用したPlayerです。

他の音声再生エンジンへの乗り換えやプロトタイピング、小規模ゲームでの使用を想定して作成されています。

#### GameObjectにアタッチ

1. UnitySoundPlayerを使用したいゲームオブジェクトのコンポーネントとしてアタッチします。
2. UnitySoundPlayerにCueSheetを設定します。
3. PlayAtParentオプションを使用するかを設定します。これは生成されたAudioSourceがGameObjectのTransformの子になるかの設定になります。GameObjectに追従して鳴らしたい場合は`true`
   にしてください

#### CueSheetの作成

1. `Assets/Create/FxPlayer/Sound/UnitySoundCueSheet`からCueSheetを作成します。
2. Cueを作成します。FxPlayerにおける再生の1単位になります。
3. CueNameを命名します。
4. 使用したいAudioClipを
5. 最大音量と最小音量を設定します。CueSheetとUnitySoundPlayerのボリュームをかけ合わせた仮想の音量になります。
6. 最大のピッチと最低のピッチを設定します。単位は`Cent`で1Centは半音の`1/100`となり、`1200Cent`で1オクターブになります。

### EffectPlayer
EffectPlayerはパーティクルエフェクトを再生するためのFxPlayerです。`IEffect`実装したコンポーネントをアタッチしたパーティクルエフェクトを再生できます。

#### EffectPrefabの作成
1. 使用したい`ParticleSystem`コンポーネントがついたゲームオブジェクトにParticleEffectをアタッチします。
2. Projectにドラッグ・アンド・ドロップし、Prefab化します。

#### CueSheetの作成
1. `Assets/Create/FxPlayer/Sound/EffectCueSheet`からEffectCueSheetを作成します。
2. Cueを作成します。FxPlayerにおける再生の1単位になります。
3. CueNameを設定します。



# Contribute

このリポジトリでは以下の協力を募集しています。

- READMEやライブラリのリファレンス等、ドキュメントの整備と翻訳
    - ココがわかりにくい、詳細に書いてほしい、実際に修正したなどがあればREADMEに追加します。
    - 英語があんまり得意ではないのでやっていただけるととても助かります。
- バグ報告と修正
  - 
- 新機能の提案と実装
    - 飛び上がるほど嬉しいです。

# Author Info

- NebusokuDev
- [Twitter](https://twitter.com/neubsoku_dev)

## Licence

"FXPlayer" is under [MIT license](https://en.wikipedia.org/wiki/MIT_License).