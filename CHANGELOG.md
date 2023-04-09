# Changelog
All notable changes to this package will be documented in this file.

## [1.1.0] - 2023-04-06

UniTask for Unity is now available ! You can use MonoFlux and [Flux("Hello World")] to create your own Action, then use "Hello World".Dispatch() and see the magic!
Summary:
- using Kingdox.UniFlux
- YourMonoBehaviour : MonoFlux
- [Flux("Key")] void MethodExamples() => Debug.Log("Hello World");
- "Key".Dispatch();

### Fixed
- Fixed Bug with Kingdox.UniFlux.Core.Internal.Flux<T, T2> where it create ActionFluxParam and FuncFlux innecessarily, now only instantiate the specified

### Changed
- Removed ISubscribe
- Removed IDictionary
- Changed Internal classes to 'internal' access
- Added dictionaries as 'readonly' property
- Removed ITriggers and implemented in each IFlux interface
- Renamed Methods to keep standard design conventions (in extension classes we keep @IEnumerator, @ITask, etc.. for compatibility)

### Added
- Added IStore to do what ISubscribe and IDictionary does, simplified
- Added Kingdox.UniFlux.Core.Flux as public static class to access internal Flux class, like a pipeline
- Added UniFlux Extension for string and int types
- Added ScriptTemplate to create your own UniFlux Extension key type

## [1.0.0] - 2023-03-24
This is the first release of *UniFlux*.

### Added
- Added Flux capabilities
- Added Extensions to Invoke and subscribe with string and int as keys
- Added support for UniTask from 'Cysharp'
- Editor to Invoke Flux Methods by Inspector (no available with parameters or return value)




<!-- 
    Template 
    ## [1.0.0] - 2023-12-31 
    This is the a commit

    ### Added
    ### Fixed
    ### Changed
    ### Unreleased
    # Changelog
-->