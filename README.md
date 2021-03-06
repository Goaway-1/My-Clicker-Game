# Clicker Game
> ## 목차
 - [게임소개](#Infomation)
 - [게임화면](#게임화면)
 - [사용기술](#사용한-기술-및-배운점)
 - [개선점](#개선점)
___
> ## Infomation
  <img src="Capture/After/Main.jpg" height="300" title="Game Icon">

|||
|:--:|:--|
|이름|Clicker Game|
|설명|앞으로 진행하며 나오는 몬스터들을 잡아 능력치를 올리는 흔히 생각하는 클리커게임이다.|
|특징|공격모션(5가지)들이 각각 다른 특징를 가지고 있다는 점이다. 또한 이 모션을 절적히 배치해서 또 다른 추가 효과를 얻을 수 있다.|
|제작기간| 20년12월22일 ~ 21년02월23일 (56일)|
|초기목표|단순한 클릭게임이지만 액션의 화려함과 다양한 공격모션 구현으로 인한 뻔한 클리커게임 벗어나는 것이 목표, 하지만 원하는데로 이루어지지 않았다.|
|에셋|모든 에셋들은 Unity Asset Store에서 사용 (상업적으로 사용하지 않음)|
|자세한 제작과정|[DevRecord 파일 확인](https://github.com/Goaway-1/My-Clicker-Game/blob/main/DevRecord.md)|
|다운로드 링크|[구글 드라이브](https://drive.google.com/file/d/1wtfZB9dNxa4Bv-HKaRZXgeAvQvcxIDal/view?usp=sharing) // 플레이스토어에 등록X (저작권 관련)|
___
> ## 게임화면
|이미지 & 설명||
|:--:|:--:|
|<img src="Capture/Explain/1.jpg" title="LoadingScene" width="200">|- 메인화면이며 json 파일의 로딩과 페이크로딩을 사용하여 진행했다.|
|<img src="Capture/Explain/2.jpg" title="MainScene" width="200">|- 로딩이 모두 끝난후의 화면으로 본격적으로 게임을 즐길수 있는 화면이다. <br>- 단순히 화면을 클릭하면 몬스터를 공격하는 방식이다.<br>- 단점 : 초기에는 공격모션이 지정되어 있지 않아 모션이 나오지 않는다. Combo창에 가서 모션을 지정해 주어야한다.|
|<img src="Capture/Explain/3.jpg" title="BeforeUpgradeScene" width="200" style="display:block;">|- 기본 공격력, 크리티컬 확률, 자동 클릭 3가지를 업그레이드 할 수 있는 UI이다.|
|<img src="Capture/Explain/4.jpg" title="AfterUpgradeScene" width="200" style="display:block;">|- 업그레이드 가능 : 녹색, 업그레이드 불가 : 빨간색<br>- 오른쪽 상단은 오디오의 뮤트,언뮤트이다.|
|<img src="Capture/Explain/5.jpg" title="ComboScene" width="200" style="display:block;">|- 공격모션을 추가하고 업그레이드 할 수 있는 UI<br>- 공격모션의 순서에 따라 숨겨진 추가 데미지 존재|
|<img src="Capture/Explain/6.jpg" title="MissonScene" width="200" style="display:block;">|- Misson을 진행하고 그에 대한 보상을 받을 수 있는 UI<br>- 클릭 횟수와 스테이지별 보상이 존재하며, 한번에 받을 수 있는 기능은 없다.|
|<img src="Capture/Explain/7.jpg" title="MaterScene" width="200" style="display:block;">|- Master UI는 실험할때 사용하는 창이다. <br>- 게임머니를 추가할때 Increased_Money 버튼을, 몬스터를 죽일때는 Kill_Enemy를, 데이터의 초기화를 원하는 경우에는 JsonData_Reset 버튼을 사용한다.<br>- Kill_Enemy버튼은 오류가 발생할 수 있으니 되도록 사용하지 않는것이 좋다.|
|<img src="Capture/Explain/Playing.gif" title="PlayingScene" width="200" style="display:block;">|- 플레이화면|
___
> ## 사용한 기술 및 배운점
  - 오브젝트 폴링
    - 가비지(쓰레기)값을 줄이기 위해 사용
    - 데미지를 출력하는 부분에서 사용
  - 싱글톤
    - DataManager와 같이 통제하는 역할을 갖는 .cs파일에서 사용
    - 과도한 사용은 하지 않았다.
  - json활용법  
    - Json을 활요해서 데이터를 저장
    - 또한 비트로 전환하므로써 일반인들이 건들일수게 보안 강화
  - 전처리기
    - 문법 습득
  - 최적화 관련 작업 (profiler 사용법...)
    - update를 많이 사용하면 안되는것으로 알고 있음
    - Profiler를 통해서 확인은 가능했지만 최적화는 많이 이루어져 못했다.

___
> ## 개선점
  - 업그레이드 비용의 밸런스
  - 애니메이션의 최적화
  - Json배열 사용법
  - NGUI의 개선 
  - 스킬다양화(밸런스), json의 배열, 몬스터 오브젝트 풀링, 부활(0.12버전에서 할 예정)