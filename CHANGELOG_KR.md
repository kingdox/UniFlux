# 변경 로그
이 패키지에 대한 모든 주목할만한 변경 사항은 이 파일에 문서화됩니다.
## [1.3.1] - 2023-04-30
### 수정됨
- Internal.State가 이전에 디스패치된 경우 스토어에서 호출하도록 수정했습니다.
- Internal.State가 상태 변경시 디스패치에서 호출하도록 수정했습니다.
## [1.3.0] - 2023-04-23
### 추가됨
- 상태가 있는 스토어를 처리하기 위해 FluxState, State 및 StateFlux를 추가했습니다.
- 상태 관리 메서드를 처리하기 위해 Core.Flux StoreState 및 DispatchState에 추가되었습니다.
- 확장에 StoreState 및 DispatchState 구현
### 실험적
- 스크립터블 객체를 저장 및 디스패치 키로 사용할 수 있도록 허용. 이를 통해 모듈이 더 모듈화되지만 더 많은 상용구가 생깁니다.
### 제거됨
- 액션플럭스 파라미터에 대한 딕셔너리_읽기를 제거했습니다.
## [1.2.2] - 2023-04-20
### Fixed
- FuncFlux 및 FuncFluxParam은 키당 하나만 추가하도록 설계되었지만 대신 여러 키를 추가 할 수 있으므로 최적화의 복잡성을 줄이기 위해 Func< TResult >를 TStorage로 사용하기 만하면됩니다.
### 제거됨
- ActionFlux, ActionFluxParam, FuncFlux 및 FuncFluxParam에서 dictionary_read를 제거했습니다.
## [1.2.1] - 2023-04-17
### 수정됨
- 저장 메서드가 구독을 취소 할 때 첫 번째 저장소를 추가 할 수 있지만 다음 저장소를 구독하거나 구독 취소 할 수 없도록 저장소에서 저장소를 제거하도록 수정되었습니다.
## [1.2.0] - 2023-04-09
이제 UniFlux가 이전보다 더 최적화되었습니다.
### 추가됨
- 최적화를 위해 ActionFlux dictionary_read에 추가되었습니다.
- 최적화를 위해 ActionParamFlux dictionary_read에 추가되었습니다.
- 최적화를 위해 FuncFLux dictionary_read에 추가됨
- 최적화를 위해 FuncParamFLux dictionary_read에 추가되었습니다.
### 제거됨
- IStore에서 사전 계약 제거
- 아직 테스트가 포함되어 있지 않아 테스트 플레이모드 제거
최적화됨 ### 최적화됨
- 100.000 반복 문자열 키 => 25ms에서 ~15ms로 최적화 디스패치 최적화
- 최적화 저장 ~10.000 반복 문자열 키에서 추가 => [300ms GC.Alloc 380MB] 에서 [~15ms GC.Alloc 2.9MB] 로 변경되었습니다.
- 최적화 저장 ~10.000 반복에서 제거 문자열 키 => [300ms GC.Alloc 380MB] ~ [~15ms GC.Alloc 2.9MB]
## [1.1.1] - 2023-04-09
## [1.1.1] - 2023-04-09
### 추가됨
- 작은 원근법 보기를 위해 "Architecture.io"를 추가했습니다.
- 서비스 템플릿 추가
- 패키지 사용 방법 샘플 추가
- Unity 편집 모드(WIP 플레이 모드)에 대한 유닛 테스트 추가
- 작은 문서 추가
### 변경됨
- 구독 메서드에서 FluxAttribute.cs 변경(이전 구조도 제거)
- 두 개 이상의 클래스가 있는 스크립트를 단일 스크립트로 변경하여 다른 스크립트를 사용하도록 변경했습니다.
## [1.1.0] - 2023-04-06
유니티용 UniFlux가 출시되었습니다! MonoFlux와 [Flux("Hello World")]를 사용하여 자신만의 액션을 만든 다음 "Hello World".Dispatch()를 사용하면 마법을 볼 수 있습니다!
요약:
- Kingdox.UniFlux 사용
- YourMonoBehaviour : MonoFlux
- [Flux("Key")] void MethodExamples() => Debug.Log("Hello World");
- "Key".Dispatch();
### Fixed
- Kingdox.UniFlux.Core.Internal.Flux<T, T2>에서 불필요하게 ActionFluxParam과 FuncFlux를 생성하던 버그가 수정되어, 이제 지정된 것만 인스턴스화합니다.
### 변경됨
- ISubscribe 제거
- IDictionary 제거
- 내부 클래스를 '내부' 접근으로 변경
- 사전을 '읽기 전용' 속성으로 추가했습니다.
- ITriggers를 제거하고 각 IFlux 인터페이스에 구현했습니다.
- 표준 디자인 규칙을 유지하기 위해 메서드 이름 변경 (확장 클래스에서는 호환성을 위해 @IEnumerator, @ITask 등을 유지)
### 추가됨
- IStore를 추가하여 ISubscribe 및 IDictionary가 수행하는 작업을 단순화했습니다.
- 파이프라인처럼 내부 Flux 클래스에 접근하기 위해 공용 정적 클래스로 Kingdox.UniFlux.Core.Flux를 추가했습니다.
- 문자열 및 정수 유형에 대한 UniFlux 확장 추가
- 스크립트 템플릿을 추가하여 자신만의 UniFlux 확장 키 유형을 생성할 수 있습니다.