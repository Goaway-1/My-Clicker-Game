# Dev Story

## Description for Dev Stroy
`Expain My third project and I want to make use of various tools useful. :)`
___
## Default
|Value|StartValue|UpgradeValue|StartCost|UpgradeCost|MaxValue|Rebirth|
|:---:|:---:|:---:|:---:|:---:|:---:|:---:|
|Power| 1.0f | 10level -> +0.2f | 1 | 3stage -> +1 | None  | +0.2f |
|Critical| 10% | +0.25f | 20 | None | 70% | +0.25f |
|DropMoney| 1~2 | 10stage -> 1 | None  | None  | None | +1 |
|AutoClick| None(3f) | -0.05f  | 10 | pow(1.3f/level) | 0.5f | +0.02f |
|Hp| 0f | 5f * mathf(5f,0.4/stage) // 5f+5씩 | None | None | None | None |

## SKill

|Skill|Index|Increased Type|Default Additional|Upgrade Additional|StartCost|UpgradeCost|Condition|
|:---:|:---:|:---:|:---:|:---:|:---:|:---:|:---:|
|Default|None|None|None|None|None|None|0 Stage|
|item1(Outline Punch)|1|Power|+0.1|+0.1|5|pow|10 Stage|
|item2(Kick)|2|Power|+0.5|+0.5|15|pow|20 Stage|
|item3(Strite Punch)|3|Critical|+5%(0.05%)|+1%(0.01%)|10|pow|20 Stage|
|item4|4|BossTime|+0.1|+0.1|20|pow|10 Stage|
|item5|5|Gold|+1|+1|20|pow|50 Stage|
___
## __12.22__
> **<h3>Today Dev Story</h3>**
 - 클리커게임을 위해 클릭, 돈, 클릭per돈 등을 구현만 해두었다.
 - PlayerPrefabs.SetInt() 와 PlayerPrefabs.GetInt()를 통해서 local에 저장했다. 작은 메모리에서만 사용가능하니 ~~<ins>Json으로 추후 변경해야한다.</ins>~~
 - 오후에는 [수업](https://www.youtube.com/watch?v=5obCdTnlEFo)을 모두 듣고 나만의 것을 따로 만들어 구현할 것이다.

> **<h3>Realization</h3>**
- 싱글톤에 대해서 배웠다. 하나의 스크립트를 다른 스크립트에서 사용할때 아래 방식처럼 매 스크립트를 호출해서 사용하거나
```
public Manager manager; 
manager.~~();
``` 
- 또는 사용할 스크립트에 들어가서 static으로 <mark>__싱글톤화__</mark> 해준 후 사용해도 된다. 싱글톤을 사용하면 편리하게 다른 스크립트 내용을 불러올 수 있어 간편하지만 남용하면 접근성에 있어 약점을 보이게 된다. 

```
private static Manager instance;
  public static Manager GetInstance()
  {
	if(instance == null)
	{
	    instance = FindObjectOfType<Manager>();
	    if(instance == null)
	    { 
 	  	GameObject container = new GameObject("Manager");
	  	instance = container.AddComponent<Manager>();
    	}
	}
	return instance;
  }
```
___
## __12.23__
> **<h3>Today Dev Story</h3>**
 - 프로젝트를 제작하기 시작했다.
 - Enemy, Player, itemButton, DataManager, UIManger를 구현
 - 공격버튼시 강제로 돈이 추가된다는 점과 적 생성에 있어 오류 ~~(수정필요)~~
 - 깃허브를 활용해서 저장하여 제작 과정을 기록
 - Playerfabs에 사용될 데이터(Power,Critical....)들의 정보들을 정리하지 못함
> **<h3>Realization</h3>**
 - NULL
___
## __12.24__
> **<h3>Today Dev Story</h3>**
  - EnemyManager를 수정해서 죽고 2초 뒤에 생성 <ins>(수정필요)</ins> 
  - Player, Enemy 두가지 데이터의 상태들을 제작, power업그레이드를 완벽하게 구현
  - power표시 오류 수정 및 PlayerState를 싱글톤화 하지 않고 DataManager에서 할당해서 사용 
  - stage별 enemy 체력 상승에 대한 문제발생 -->  EnemyManager에서 관리필요 (stage대비)
  - player에서 enemy의 피를 깍기 위해서 enemymanager를 거치게 하고 싶다. <ins>(수정필요)</ins> 
> **<h3>Realization</h3>**
 - NULL
___
## __12.25__
> **<h3>Today Dev Story</h3>**
 - Critcal (Pow,Per) 2가지를 Random.Range()함수로 구현하려 했으나, 더욱 확실하게 구현하기 위해서 __<mark>"의사 난수 알고리즘"</mark>__ 을 학습
> **<h3>Realization</h3>**
 - LCG(선형 합동법)이 대표적이며 이외에도 Mersenne Twister, PCG, xoroshro가 존재
   - __선형 합동법(LCG)__   
장점 : 로컬 시간을 이용하여 계산하며, 공식이 쉽고 빠름, 또한 적은 메모리로 구현가능  
단점 : 1차원은 괜찮지만 n차원이상은 일정 패턴이 보여 플레이어가 예측가능하게 된다.

   - __메르센 트위스터(Mersenne Twister)__     
장점 : 주기가 길며, 다른 생성기의 결점들을 고려해서 만들었다. 그렇기에 동일분포률을 갖는다.(n차원이 623차원까지)  
단점 : 구현에 있어 복잡함
___
## __12.26__
> **<h3>Today Dev Story</h3>**
 - 메르센 트위스터와 XOR 스프트를 구하려 했으나 시간을 사용하는 LCG를 사용 
 - C#은 구현방식이 달라 다시 학습 필요
> **<h3>Realization</h3>**
 - NULL
___
## __12.27__
> **<h3>Today Dev Story</h3>**
 - NULL
> **<h3>Realization</h3>**
 - NULL
___
## __12.28__
> **<h3>Today Dev Story</h3>**
 - 유니티에서 의사난수 알고리즘 필요 X -> <ins>Random.range()</ins>사용
 - 모든 Player State를 float형으로 전환
 - Player 애니메이션 idle, attack만 보기 쉽게 구현
 - 공격은 IEnumerator를 통해서 return new waitforsecond()를 통해 대기 시간 후 자동으로 공격 모션의 bool값을 false로 변환, 임시 방편일 뿐이다. <ins>(수정필요)</ins> 
 - random.range() 함수를 float형으로 반환하기 위해서 2가지 대안
   1. 두 가지 정수를 받고 첫번째 수에서 두번째 수를 서로 나누어 나오는 값, 하지만 작은 수의 분포가 더 높다.
   2. 두 가지의 정수를 받아 두 번째 수를 소수점으로 변경 후 두 수를 더하는 방식

> **<h3>Realization</h3>**
 - NULL
___

## __12.29__
> **<h3>Today Dev Story</h3>**
 - power,critical등의 변수들을 float형으로 전환
 - Buttons 클래스를 만들고 상속을 통해서 모든 버튼(Power, Critical)을 상속, ~~미완성~~
```c#  
public abstract class Buttons : MonoBehaviour
{
  public string upgradeName;
  public Text upgradeDisplay;
  public int level;

  //업그레이드 비용
  public int currentCost;         //지금 비용
  public int startCurrentCost;    //시작 비용
  public float UpcostPow;         //비용증가 pow

  //업글 제곱
  public float costPow;       //State 강화 pow
  public float startState;    //현재 state

  public CanvasGroup canvasGroup;                 //Alpha값을 조정하기 위한 그룹
  public Slider slider;
  public Color upgradeAbleColor = Color.blue;     //업그레이할때 변함
  public Color notUpgradeAbleColor = Color.red;   //업그레이드 전
  public Image colorImage;
  public bool isPurchased = false;               //아이템 구매여부

  public abstract void PurchaseUpgrade();
  public abstract void UpdateItem();
  public abstract void UpdateUI();
}
```
> **<h3>Realization</h3>**
 - NULL
___
## __12.30__
> **<h3>Today Dev Story</h3>**
 - 몬스터 사망 판단 수정 (Update로 이동) 및 공격 수정
 - Buttons 상속 구현 완성, 크리티컬 확률과 퍼센트 버튼 생성 및 상속사용
 - 몬스터의 등장을 구현 <ins>(추후 수정)</ins>
 - 인터페이스 구상 및 재현
> **<h3>Realization</h3>**
- 이동에 대해 4가지 학습, MoveToWards를 활용해서 몬스터의 등장을 구현
  1. Vector3.MoveToWards(transform.postion, target_pos, speed) : 일정한 속도로 이동
  2. Vector3.SmoothDamp(transform.postion, target_pos, ref velo, speed) : 부드러운 이동. 마지막 레퍼런스에 반비례해서 속도 증가//Vector3 velo = Vector3.zero; (참조값)
  3. Vector3.Lerp(transform.postion, target_pos, speed) : 부드러운 이동, smoothDamp보다 감속이 길다.
  4. Vector3.SLerp(transform.postion, target_pos, speed) : 호를 그리며 이동


## __12.31__
> **<h3>Today Dev Story</h3>**
 - readme 파일 수정을 위한 markdown 학습 
 - 내일은 일기를 다시 갱신 예정
> **<h3>Realization</h3>**
 - visual studio code를 통해서 작성, HTML과 비슷한 구조
 - 개발자 각자의 메모장이라는 개념

___
__<h2>Happy New Year!!</h2>__

#### 이제 24살이여 

___
## __1.1__
> **<h3>Today Dev Story</h3>**
 - Dev Story 작성 및 수정
> **<h3>Realization</h3>**
 - NULL

___
## __1.2__
> **<h3>Today Dev Story</h3>**
- 모니터 와서 못했엉.
> **<h3>Realization</h3>**
 - NULL
___
## __1.3__
> **<h3>Today Dev Story</h3>**
- 몬스터 다가 올때만 배경 추가 및 움직임 구현
- EnemyManager에서 Instantiate사용시 0.85초간 이동하게 만듬 <ins>(추후 수정)</ins>
- 한번만 이동하고 다시 이동하지 않는다. ~~<ins>(추후 수정)</ins>~~
  ```c#
  void Update()
	{
    if (EnemyManager.GetInstance().isMove)  //isMove가 true일때만 배경을 움직인다.
		{
			Move();
		}
        else
        {
			currentTime = 0;
        }

		if (currentTime >= MoveTime && EnemyManager.GetInstance().isMove)	//일정 시간이 지나면 배경을 정지한다. 
		{
			EnemyManager.GetInstance().isMove = false;
		}
	}
  ```

- boss 출현시 timer 작동(EnemyManager에서 UIManager의 DecreaseTime()호출) <ins>(추후 수정)</ins>
```c#
    public void DecreaseTime()  //시간 감소
    {
        Slider.SetActive(true);
        StartCoroutine(wait());
    }
    public IEnumerator wait()
    {
        while (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            timeSlider.value = currentTime / MaxTime; //출력
            yield return new WaitForFixedUpdate();
            Debug.Log(currentTime);
        }
        if(currentTime <= 0)
        {
            Slider.SetActive(false);  //비활성화
        }
    }
```
- 10stage마다 boss출현 (제한 시간내에 잡지 못하면 다시 n번째 스테이지로 돌아간다.) <ins>(추후 수정)</ins>


> **<h3>Realization</h3>**
 - 배경을 움직이는 방법 2가지
 1. n개의 배경을 만들어 놓고 transform.postion을 이동시켜 교차하면서 사용하기
> 결과
<img src = "Capture/bg_Move.gif" width="600">

```c#
public class MoveBackground : MonoBehaviour 
{
	public float speed;
	private float x;
	public float PontoDeDestino;
	public float PontoOriginal;

	void Start () {
		//PontoOriginal = transform.position.x;
	}
	
	void Update () {
		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);

		if (x <= PontoDeDestino){
			x = PontoOriginal;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}
	}
}
```

1. Material을 이용해서 TextureOffset을 이용해 그림 자체의 offsetX를 이동시키기 {이미지를 default 변환, Wrap Mode -> Repeat로 설정 및 Martial 생성(shader -> Unlit/Transparent로 설정)}

> Material 설정방법
<img src="Capture/Material_1.gif" heigth="350">

> 결과
<img src="Capture/Material_2.gif" heigth="350">

- ### 구름은-항상-움직이게-수정
```c#
[System.Serializable]
public class BGScrollData
{
  public Renderer RenderForScroll;
  public float Speed;
  public float OffsetX;
  public bool Always;   //(2.9일 추가) 구름의 움직임을 위함
}

public class BGScroller : MonoBehaviour
{
  [SerializeField]
  BGScrollData[] ScrollDatas;

  void Update()
  {
    if (EnemyManager.Instance.isMove)  //isMove가 true일때만 배경을 움직인다.
    {
      updateScroll();
    }
    else
    {
      currentTime = 0;
    }

    if (currentTime >= MoveTime && EnemyManager.Instance.isMove)    //일정 시간이 지나면 배경을 정지한다. 
    {
      EnemyManager.Instance.isMove = false;
    }
  }

  void updateScroll()
  {
    for (int i = 0; i < ScrollDatas.Length; i++)
    {
      if (!ScrollDatas[i].Always) //(2.9일 추가)
      {
        SetTextureOffset(ScrollDatas[i]);
      }
    }
  }

  void SetTextureOffset(BGScrollData scrollData)
  {
    //값들을 증가 시킨다.
    scrollData.OffsetX += (float)(scrollData.Speed) * Time.deltaTime;
    if(scrollData.OffsetX > 1)
    {
      scrollData.OffsetX = scrollData.OffsetX % 1.0f;
    }
    Vector2 offset = new Vector2(scrollData.OffsetX, 0);

    //텍스쳐 이동
    scrollData.RenderForScroll.material.SetTextureOffset("_MainTex", offset);
  }

  IEnumerator set(BGScrollData scrollData)    //(2.9일 추가)
  {
    while (true)
    {
      scrollData.OffsetX += (float)(scrollData.Speed) * Time.deltaTime;
      if (scrollData.OffsetX > 1)
      {
        scrollData.OffsetX = scrollData.OffsetX % 1.0f;
      }
      Vector2 offset = new Vector2(scrollData.OffsetX, 0);

      //텍스쳐 이동
      scrollData.RenderForScroll.material.SetTextureOffset("_MainTex", offset);
      yield return new WaitForSeconds(0f);
    }
  }
}
```
- 나는 1번안을 통해서 사용했다. (이유 : 이미지의 offsetX값을 수정하기엔 이미지가 이상있어서)
___
## __1.4__
> **<h3>Today Dev Story</h3>**
 - 배경 이동 속도 및 한번만 이동하는 오류 수정.
 - 타이머 작동 중 몬스터(보스)가 죽으면 종료, 죽지 않았다면 스테이지를 하락 
   - #### 보스-돈-수정
   - #### 골드 증가 수정(10stage마다)
 - 타이머할때만 slider.setative 활성화

<img src= "Capture/BossTimer.gif" width="350">

```c#
//UIManager 내부
public void DecreaseTime()  //시간 감소
{
  Slider.SetActive(true);
  StartCoroutine(wait());
}
IEnumerator wait()   //시간 감소를 위한 대기시간을 위해 만듦
{
  while (currentTime >= 0)
  {
    currentTime -= Time.deltaTime;
    timeSlider.value = currentTime / MaxTime; //출력
    yield return new WaitForFixedUpdate();  //프레임 대기
    if (!EnemyManager.GetInstance().getExist()) //몬스터 뒤짐
    {
      DataManager.Instance.goldPerTake++; //골드 개수 증가
      break;
    }
  }
  if (EnemyManager.GetInstance().getExist()) //몬스터 뒤지지 않았다면 삭제후, 스테이지 초기화
  {   
    Enemy.GetInstance().bossNotDead();  //수정(21.01.17)
    DataManager.GetInstance().DecreaseStage();
  }
  Slider.SetActive(false);
  currentTime = 10f;
}
//Enemy 내부
public void bossNotDead()   //보스가 죽지 않았을때의 판전
{
    EnemyManager.Instance.setExist(false);
    Destroy(this.gameObject);
}
```
  - 공격시 데미지를 텍스트로 띄우기 위해서 text를 사용하려 했으나 기존 text는 panel위에서 사용해야하기 때문에 3D에 있는 3D Text를 사용 
  - 동시에 오브젝트 풀링을 사용해서 최적화
  - ### Effect-위치수정

<img src = "Capture/ObjectPooling.gif" width="350">

```c#
  ///ObjectPooling 기획
  public static ObjectPoolingManager instance;

  public GameObject m_goPrefab = null;    //여기에 텍스트가 들어간다.
  public Queue<GameObject> m_queue = new Queue<GameObject>(); //저장시킬 큐(장소)

  void Start()
  {
    instance = this;
    GameObject effectpos = GameObject.Find("EffectManager");
    for (int i = 0; i < 30; i++)    //추후 개수 수정
    {
      GameObject D_object = Instantiate(D_goPrefab, effectpos.transform, false);   //프리펩을 게임내의 객체로 생성한뒤 큐에 저장
      D_queue.Enqueue(D_object);
      D_object.SetActive(false);
    }
  }

  public void InsertQueue(GameObject p_object) //사용한 객체를 풀에 반납하는 함수
  {
    D_queue.Enqueue(p_object);
    p_object.SetActive(false);
  }

  public GameObject GetQueue()    //풀에서 객체를 불러와 사용하는 함수
  {
    GameObject t_object = m_queue.Dequeue();
    t_object.SetActive(true);
    return t_object;
  }
```

```c#
//effect Manager
  public static EffectManager instance;

  private void Start()
  {
    instance = this;
  }

  public void attckShow()
  {
    GameObject t_object = ObjectPoolingManager.instance.GetQueue();
    t_object.transform.position = randPos();
  }

  private Vector3 randPos()   //pos의 위치를 랜덤으로 한다.
  {
    float a = Random.Range(-0.5f, 0.5f);
    float b = Random.Range(1f, 2f);
    return new Vector3(a, b, -1.1f);
  }
```

```c#
//Effect
Rigidbody m_myrigid = null;
public TextMesh m_text = null;
private float transparency = 1f; //투명도

private void OnEnable() //활성화 될때마다
{
if (m_myrigid == null)
{
  m_myrigid = GetComponent<Rigidbody>();
}
  transparency = 1f;
  m_text.color = new Color(0, 0, 0, 1f);
  m_myrigid.velocity = Vector3.zero; //초기화 필수(속도값)
  setDamageText(AttackButton.getDamage());  //데미지를 설정한다.  
  m_myrigid.AddExplosionForce(100, transform.position, 1f);
  StartCoroutine(DestoryCube());
}

public void Update()
{
  transparency -= Time.deltaTime;
  m_text.color = new Color(0, 0, 0, transparency);
}

IEnumerator DestoryCube()
{
  yield return new WaitForSeconds(0.7f);  //추후 수정
  ObjectPoolingManager.instance.InsertQueue(gameObject);
}

public void setDamageText(float power)       //DamageText 설정
{
  m_text.text = "" + power;
}
```
 - ### show버튼을 제작해 인터페이스창의 비/활성화 구현
<img src= "Capture/ShowState.gif" width="350">
 - ### Master버튼을 제작해 몬스터를 죽이고,돈을 무한으로 변경(이미지)

> **<h3>Realization</h3>**
  - 오브젝트 폴링에 대한 학습했다. 이는 기존 오브젝트를 생성하고 파괴하는 방식이 아닌 일정한 수많큼 오브젝트를 <mark>**생성해 놓고 돌려쓰는**</mark> 개념이다.
  - 순서를 정리하자면 pooling 클래스를 싱글톤화 한 후/ Queue 저장공간할당/ 시작과 동시에 오브젝트들을 생성한다.
  - 썻던 오브젝트를 재사용하는 것이기 때문에 사용후에는 초기화가 필수로 필요하다.
  - 오브젝트 파괴(Destory함수) 대신에 Enqueue(GameObject)를 통해서 반환하고, 생성시 DeQueue()를 통해서 미사용중인 오브젝트를 불러온다. 
  - 이는 총알같은 오브젝트에서 자주 사용하며 최적화에 도움을 준다.
___
## __1.5__
> **<h3>Today Dev Story</h3>**
- Enemy의 HP 상태를 띄우기 위해서 EnemyManager에 Slider를 할당하고 Enemy가 끌어다쓰는 방식으로 구현
- 몬스터가 없을때 사라지거나 초기화 되는 것 <ins>(추후 수정)</ins> <img src="Capture/HpGauge.gif" width="350">
- player의 이미지와 애니메이션을 수정 <img src="Capture/Animation.gif" width="350">
- 모든 스크립트의 싱글톤과 power와 같이 자주 쓰는 변수들을 <mark>접근자 프로퍼티</mark>로 설정했다. 더 이상 따로 호출과 적용 함수를 만들지 않고 get; set;을 통해 간결하게 적용가능하다. (아래는 예시이다.)
```c#
public float power  //힘
{
    get
    {
      return PlayerPrefs.GetFloat("power", 1f);
    }
    set
    {
      PlayerPrefs.SetFloat("power", value);
    }
}
```
 - 접근자 프로퍼티 설정 후 DamageText에서 오류가 발생해 수정, 하지만 static으로 진행한 임시 방편 <ins>(추후수정)</ins>
> **<h3>Realization</h3>**
- int형의 값이 overflow 될수 있기에 long형으로 변환하는법
- 변환했을때 접근자 프로퍼티를 설정하는 방법
- 장점 : 굳이 호출하는 함수를 따로 제작 X, 시작시 호출 X, 싱글톤에서도 사용 O,
```c#
public long gold
{
  get
  {
    if (!PlayerPrefs.HasKey("Gold"))    //만약 Gold가 할당되어 있지 않다면 0을 반환 --> 저장X
    {
      string str = PlayerPrefs.GetString("Gold"); //문자열로 받고
      return long.Parse(str); //long형으로 반환후에 return
    }
  }
  set
  {
    PlayerPrefs.SetString("Gold", value.ToString());
  }
}
```
___
## __1.6__
> **<h3>Today Dev Story</h3>**
 - null
> **<h3>Realization</h3>**
 1. 스크롤 바
  - Canvas - Scroll View - Viewport - Mask -> 스크린상 넘치는것 표현유무
  - Viewport를 아래로 늘린다.
  - content 아래에 이미지 삽입후 Horizional 고정 해제 후 그냥 사용가능
 2. 투명도 설정
    - Item Button에 Canvas Group 추가 후 Alpha로 투명도 설정
  
    ```c#
    if (isPurchased)    //구매를 했다면 투명도
    {
      canvasGroup.alpha = 1.0f;
    }
    else   //아니라면
    {
      canvasGroup.alpha = 0.6f;
    }
    ```
___
## __1.7__
> **<h3>Today Dev Story</h3>**
 - null
> **<h3>Realization</h3>**
  1. Slider 설정
   
    ```c#
    slider.minValue = 0;  //최소값
    slider.maxValue = currentCost;  //최댓값
    slider.value = DataManager.Instance.gold; //현재 값
    ```
___
## __1.8__
> **<h3>Today Dev Story</h3>**
 - null
> **<h3>Realization</h3>**
 - null
___
## __1.9__
> **<h3>Today Dev Story</h3>**
 - null
> **<h3>Realization</h3>**
 - ### 데이터 저장의 방법 (1)PlayerPrefs (2)바이너리 파일 (3)Json
 - **PlayerPrefabs** : 기본형의 데이터를 문자열과 함께 저장, 암호화 X, 한계 존재
 - **바이너리 파일** : 물리적인 파일에 저장, 성능 우수(최적화O)
 - **Json** : "키값 : Value값" 으로 이루어짐, Data 관리 시스템을 따로 제작해야함, 암호화 가능
 - 씬 전환 시 데이터를 저장하고자 한다면 정적 클래스(static)를 통해 저장 or DontDestoryOnLoadobject 사용
 - 유니티에셋(Easy Save) : 각종 자료형, 클래스를 손쉽게 저장가능(암호화 O) 50달라

-------
 - 직렬화(Serialzation), 역직렬화(Deserialization)
 - 직렬화 : 추상적인 오브젝트를 구체적이고 저장, 전송 가능한 연속된 파일(비트)로 수정하는 것
 - 역직렬화 : 그 반대의 과정 
 - EX) Json, Bytes, XML, YAML...
```c#
using System.IO;  //추가

public class PlayerController : MonoBehaviour //MonoBehavour에는 이미 직렬화
{
  public PlayerData playerData

  [ContextMenu("To Json Data")] //함수를 그냥 실행 할 수 있게 만들어준다.
  void SavePlayerDataToJson() //Serialization
  {
    string jsonData = JsonUtility.ToJson(playerData);
    //string jsonData = JsonUtility.ToJson(playerData,true); --> true 추가시 이쁘게 정리된다.
    string path = Path.Combine(Application.dataPath,"playerData.json");
    File.WriteAllText(path,jsonData);
  }

  [ContextMenu("Load Json Data")] 
  void SavePlayerDataToJson() //Deserialization
  {
    string path = Path.Combine(Application.dataPath,"playerData.json");
    string jsonData = File.ReadAllText(path);
    playerData = JsonUtility.FromJson<PlayerData>(jsonData);
  }
}

[System.Serializable] //직렬화 가능한 데이터로 변환 (저장/편집도 가능)
public class playerData
{
  public string name;
  public int level;
  public bool isDead;
  public string[] items;
}
```
___
## __1.10__
> **<h3>Today Dev Story</h3>**
 - Json을 적용해 보려했으나 데이터들이 모두 접근자 프로퍼티가 설정되어있어 저장이 되지 않는다. ~~<ins>(추후 수정)</ins>~~
 - 화면 어느곳이던 터치(클릭)시 공격
 - 몬스터 HP, Gold 드랍 -> stage 비례 ~~<ins>(추후 수정)</ins>~~
 - power,Critical(pow,per) -> level 비례  ~~<ins>(추후 수정)</ins>~~
```c#
//몬스터 HP
private float startHp = 5f; //초기 HP
private float HpPow = 4.2f; //제곱비
float Hp = startHp * Mathf.Pow(startHp, DataManager.Instance.stage / HpPow);
  return Hp;
```
 - ### **GUI 스크롤 설정** 
 - <img src="Capture/Scroll.gif" width="350">
    1. Panel에 Vertical Layout Group설정
    2. Scroll View 생성및 스크롤바 삭제
    3. Content 안에 내용물 삽입
    4. Content, Panel의 크기를 동일한 크기로 설정(크게)
 - ### **item창 구매 화면 변경** 
 - <img src="Capture/Bar.gif" width="350">
    1. 슬라이더를 블럭에 맞게 추가 슬라이더의 Fill을 이용해서 색을 변경
    2. canvasGroup 추가(Alpha로 투명도 조절)
```c#
slider.minValue = 0;
slider.maxValue = currentCost;

slider.value = DataManager.Instance.gold;

if (isPurchased)    //투명도 조절
{
  canvasGroup.alpha = 1.0f; 
}
else
{
 canvasGroup.alpha = 0.6f;
}

if (currentCost <= DataManager.Instance.gold) 
{
  colorImage.color = upgradeAbleColor;
}
else
{
  colorImage.color = notUpgradeAbleColor;
}
```
> **<h3>Realization</h3>**
 - ### 스크롤 방법
 - ### 버튼 색 채우는 방법
____
## __1.11__
> **<h3>Today Dev Story</h3>**
 - ### 업그레드 창의 호출 및 숨김 구현 (<span style = "color:yellow;">1.애니메이션</span> 2.recttransform) 
 - <img src = "Capture/ShowMenu.gif" width="350">
```c#
//애니메이션으로 구현
public Animator ani;
public Text text; 
private bool isshow = false;

public void OnClick()
{
  if (!isshow) //위로 올라옴
    isshow = true;
    ani.SetBool("isShow", true);
    text.text = "Hide";     //text의 변화
  }
  else
  {
    isshow = false;
    ani.SetBool("isShow", false);
    text.text = "Show";
  }
}
```
 - ### DamageText 수정 완료
 - ### 분산되어 있던 GUI함수들을 UIManager에 확장
 - ### 좌우 메뉴 확장 <ins>(c# 간단하게 추후 수정)</ins>
 - <img src = "Capture/SwitchMenu.gif" width="350">
```c#
public void SwitchUpgrade()    //Button창 활성화
{
  UpgradeP.SetActive(true);
  MasterP.SetActive(false);
  MissonP.SetActive(false);
}
public void SwitchMaster()    //Master창 활성화
{
  UpgradeP.SetActive(false);
  MasterP.SetActive(true);
  MissonP.SetActive(false);
}
public void SwitchMisson()    //Misson창 활성화
{
  UpgradeP.SetActive(false);
  MasterP.SetActive(false);
  MissonP.SetActive(true);
}
```
> **<h3>Realization</h3>**
 - ### <span style = "color:yellow;">**Slot에 아이템 추가하는 방법** </span>
    1. 슬롯에 대한 정보 추가  
    ```c#
    [System.Serializable]
    public class SlotData
    {
      public bool isEmpty;
      public GameObject slotObj;
    }
    ``` 
    2. 인벤토리를 List로 생성
    ```c#
    public List<SlotData> slots = new List<SlotData>();
    private int maxSlot = 3;
    public GameObject slotPrefab;

    private void Start()
    {
      GameObject slotPanel = GameObject.Find("Panel");    //Slot을 프립펩화 한후에 Panel아래에 생성할꺼임 그래서 Panel을 찾는거임

      for (int i = 0; i < maxSlot; i++)
      {
        GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
        go.name = "Slot" + i;
        SlotData slot = new SlotData();
        slot.isEmpty = true;
        slot.slotObj = go;
        slots.Add(slot);
      }
    }
    ```
    3. 조건이 된다면 슬롯에 할당
    ```c#
    Inventory inven = collision.GetComponent<Inventory>();
    for (int i = 0; i < inven.slots.Count; i++)
    {
      if (inven.slots[i].isEmpty) //슬롯에 생성
      {
        Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
        inven.slots[i].isEmpty = false;
        Destroy(this.gameObject);
        break;
      }
    }
    ```
____
## __1.12__
> **<h3>Today Dev Story</h3>**
 - Combo창을 만들어 버튼을 누르면 창에 이미지를 삽입 (List사용)
 - 버튼 클릭시 slot 하위에 이미지만 생성 <ins>추후 수정(오브젝트 풀링 사용)</ins>
  
  <img src="Capture/SaveItem.gif" width=300>
  <img src="Capture/SavedItem.gif" width=300>

  - ### 시작시-Combo창-활성화-수정(2.12)
  ```c#
  public class InventoryManger : MonoBehaviour
  {
    public List<SlotData> slots = new List<SlotData>(); //List사용
    private int maxSlot = 3;
    public GameObject slotPrefab;
    public GameObject Panel;    //Panel의 setactive를 사용하기 위함

    public void Start()
    {
      Panel.SetActive(true);  //Panel이 활성화 되어 있지 않으면 item창이  생성되지 않아서 켰다가 끄게 만들었다.
      GameObject slotPanel = GameObject.Find("Slot_Panel");
      for (int i = 0; i < maxSlot; i++)
      {
        GameObject go = Instantiate(slotPrefab, slotPanel.transform, false); //미리 공간만 만들어 둔다.
        go.name = "Slot" + i;
        SlotData slot = new SlotData();
        slot.isEmpty = true;
        slot.index = 0;
        slot.additionalD = 0;
        slot.slotObj = go;
        slot.type = null;  //추가 공격력 및 치명타 구분
        slots.Add(slot);
      }
      Load();   //자체 로드를 통해서 수정(2.12)
      Panel.SetActive(false);
      ui.SwitchUpgrade(); //비활성화
    }
  }

  [System.Serializable]
  public class SlotData   //각 slot의 데이터
  {
    public bool isEmpty;
    public int index;           //고유 인덱스 값
    public float additionalD;   //추가 데미지
    public GameObject slotObj;  //넣을 이미지
    public string type;         //power인지 critical인지 구분
  }
  ```
  - ### 미션-데이터-수정
  ```c#
  public class ItemAddButton : MonoBehaviour  //아이템추가 버튼 (추후 변경)
  {
    public GameObject slotItem;
    public InventoryManger inven;
    public float i_additionalD;   //설정할 추가 데미지 값
    public int i_index;           //설정한 고유 index값
    public string i_type;           //설정할 추가 관여 값(power,critical,money....)

    //디스플레이
    public Text display;

    public void Add()   //추후 오브젝트 풀링으로 변경하자
    {
      for (int i = 0; i < inven.slots.Count; i++)   //빈곳에 넣는다.
      {
        if (inven.slots[i].isEmpty)
        {
        Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
        inven.slots[i].isEmpty = false;
        inven.slots[i].additionalD = i_additionalD; 
        inven.slots[i].index = i_index;
        inven.slots[i].type = i_type;
        switch (i)  //데이터의 저장
        {
          case 0:
            DataManager.Instance.slotSave.index_1 = i_index;
            break;
          case 1:
            DataManager.Instance.slotSave.index_2 = i_index;
            break;
          case 2:
            DataManager.Instance.slotSave.index_3 = i_index;
            break;
          default:
            break;
        }
        DataManager.Instance.SaveSlot();
        break;
      }
    }
  }
}
```
 - ### 장착된 Combo에 따른 %데미지 추가(관련 class수정 ItemAddButton,SlotData, InventoryManager)
 - <img src="Capture/AdditionalDam.gif" width=350> <img src="Capture/AdditionalDamEx.gif" >
```c#
//AttackButton에 Onclick()함수에 추가된 내용
//Combo 순서대로 공격
if (count == inven.slots.Count)
{
  count = 0;
}
if (inven.slots[count].additionalD != 0)    //0이 아닐때만 실행
{
  n_power += n_power * inven.slots[count].additionalD;
  Debug.Log("@@강화 공격@@"); //삭제
}
count++;
```
  - 장착된 Combo 삭제 구현(1,2,3번 클릭) 
    - ### Combo-수정
 - <img src="Capture/DelAdditional.gif" width=350>
 - ### Item-Del-수정(2.15)
```c#
public class ItemDel : MonoBehaviour  //장착시 생성되는 곳에 들어간다.
{
    private void Update()
    {
      if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())
      {
        switch (Input.inputString)  //데이터의 삭제
        {
          case "1":
            DataManager.Instance.slotSave.index_1 = 0;
            break;
          case "2":
            DataManager.Instance.slotSave.index_2 = 0;
            break;
          case "3":
            DataManager.Instance.slotSave.index_3 = 0;
            break;
          default:
            break;
        }
      DataManager.Instance.SaveSlot();
      Destroy(this.gameObject);
      }
    }
}
public class Slot : MonoBehaviour //Slot 배경에 들어간다.
{
    InventoryManger inventory;
    public int num;
    private void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<InventoryManger>();    //이렇게 받을 수도 있군 
        num = int.Parse(gameObject.name.Substring(gameObject.name.IndexOf("_") + 1));   //번호 추출
    }
    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.slots[num].isEmpty = true;
        }
    }
}
```
> **<h3>Realization</h3>**
  - PreFab화 된 오브젝트를 생성시에 이름을 정하는 방법
    - Instantiate후 obj.name = "~~"으로 설정
  - 문자열 자르기 SubString 
    ```c#
    num = int.Parse(gameObject.name.Substring(gameObject.name.IndexOf("_") + 1));   //번호 추출
    ///
    num.ToString("f2"); //길이 제한
    ```
  - InventoryManager라는 오브젝트를 찾아 InventoryManager(스크립트)를 찾음
    ```c#
    GameObject.Find("InventoryManager").GetComponent<InventoryManger>();
    ``` 
  - ### 본인 오브젝트에서 부모오브젝트중 Slot이라는 것(스크립트 등등)을 찾아 사용
    ```c#
    transform.parent.GetComponent<Slot>().num
    ```
## __1.13__
> **<h3>Today Dev Story</h3>**
  - ### Combo 창 선택시 Scroll View의 Scroll Rect 비활성화하여 스크롤 기능을 멈춤 
    ```c#
    public void SwitchCombo()    //선택하면 Active를 비/활성화 (Misson창)
    {
      UpgradeP.SetActive(false);
      MasterP.SetActive(false);
      ComboP.SetActive(true);
      MissonP.SetActive(false);
      scrollRect.enabled = false; //스크롤 비활성화
      content.anchoredPosition = new Vector2(0, -100);    //초기로 고정해버림
    }
    ```
  - ### Combo에 따른 공격 이미지 변경 <ins>(추후 변경)</ins>
  - <img src="Capture/AttackAni.gif" witdh=350>

    ```c#
    public void AttackAction(int num)
    {
      switch (inven.slots[num].index) //고유번호 사용
      {
        case 1:
          animator.SetInteger("Attack", 1);
          break;
        case 2:
          animator.SetInteger("Attack", 2);
          break;
        case 3:
          animator.SetInteger("Attack", 3);
          break;
        case 4:
          animator.SetInteger("Attack", 4);
          break;
        case 5:
          animator.SetInteger("Attack", 5);
          break;
        default:
             break;
      }
      StartCoroutine(Wait());
    }
    ```
> **<h3>Realization</h3>**
  - ### 스크립트로 컴포넌트 편집방법
    ```c#
    //추가
    GameObject.AddComponent<찾을 컴포넌트>();
    //삭제
    GameObject a = GameObject.GetComponent<찾을 컴포넌트>();
    Destory(a);
    //비/활성화
    ~~~~.enabled = true (false)
    ```
___
## __1.14__
> **<h3>Today Dev Story</h3>**
  - 공격 system 개발 
    - 3번째 공격시 각 슬롯에 있는 index가 조건에 맞는다면 3번째 공격에 추가 데미지를 발생 <ins>(추후 변경)</ins>
    - Power 계산 부분 함수화 후 분리
    ```c#
    private float sumPower()    //Power 계산하는법
    {
      if (strikePer >= rand)  //크리티컬 공격!
      {
        n_power *= strikePow;  //대안생각하기
        Debug.Log("크리티컬");
      }
      if (count == inven.slots.Count)
      {
        count = 0;
      }
      if (inven.slots[count].additionalD != 0)    //0이 아닐때만 실행
      {
        if (count != 2)  //원래는 3인데 0부터 시작했으니 2가 되야한다.
        {
          n_power += n_power * inven.slots[count].additionalD;
        }
        else        //조건이 맞다면 3타 가능
        {
          Debug.Log("@@3번째 강화 준비@@");
          if (inven.slots[0].index == 1 && inven.slots[1].index ==  2 && inven.slots[2].index == 3)    //못줄이나...?
          {
            n_power += n_power * 3;
            Debug.Log("@@3번째 강화 공격@@"); //삭제
          }
          else if(inven.slots[0].index == 1 && inven.slots[1].index == 2 && inven.slots[2].index == 4)
          {
            n_power = 99999999;
            Debug.Log("@@3번째 강화 공격(즉살)@@"); //삭제
          }
        }
      }
      return n_power;
    }
    ```
> **<h3>Realization</h3>**
  - [소수점 처리 관련](https://dodnet.tistory.com/4406)
  - System.Math.Round(float a, int b) : a의 소숫점을 b 자리 까지 남기고 반올림
___
## __1.15__
> **<h3>Today Dev Story</h3>**
  - 아파
> **<h3>Realization</h3>**
  - null
___
## __1.16__
> **<h3>Today Dev Story</h3>**
  - 늦은 귀가
> **<h3>Realization</h3>**
  - null
___
 ## __1.17__
> **<h3>Today Dev Story</h3>**
  - 공격데미지 소수점처리 
  - <img src="Capture/Damage(float).gif" width=350>
   
    ```c#
    n_power = (float)System.Math.Round(n_power,2); //2자리수까지만 표현
    ``` 
  - [보스를 못잡아도 돈 증가오류 수정](#보스-돈-수정)
  - Combo메뉴에서 다른 메뉴변경 시 스크롤이 안되는 오류 수정
  - Auto Click 구현 (Default -> 1f) <ins>(추후 수정)</ins>
  - <img src="Capture/AutoClick.gif" width=350>
    
    ```c#
    //AttackButton 에 구현
    private void Start()
    {
        StartCoroutine(Auto());
    }
    IEnumerator Auto()  //자동 클릭
    {
      while (true)
      {
        OnClick();
        yield return new WaitForSeconds(DataManager.Instance.AutoC);
      }
    }
    ```
    ```c#
    //다른 Buttons를 상속받은 버튼과 동일하다. 감소되는 정도만 다르다.(고정) ->AutoClickButton의 내용
    DataManager.Instance.AutoC -= costPow;    //감소 0.05f

    //DataManager에 추가된 내용
    [HideInInspector]
    public float AutoC  //자동 클릭 시간
    {
      get
      {
        return PlayerPrefs.GetFloat("auto", 1f);
      }
      set
      {
        PlayerPrefs.SetFloat("auto", value);
      }
    }
    ```
  - 애니메이션 작성 및 수정 <ins>(추후 수정)</ins>
  - <img src="Capture/NAnimation.gif" width=350>
> **<h3>Realization</h3>**
  - null
___
## __1.18__
> **<h3>Today Dev Story</h3>**
  - ## 밸런스패치 진행
  - Power_level이 10상승할때 마다 0.2f씩 공격력 증가하는 폭이 상승, 또한 Power 증가함수를 제거
    ```c#
    if (DataManager.Instance.gold >= currentCost)
    {
      DataManager.Instance.gold -= currentCost;
      DataManager.Instance.power += costPow;    //수정
      DataManager.Instance.SavePowerButton(this); 

      level++;
      if (level % 3 == 0)
      {
        UpdateItem();
      }
      if (level % 10 == 0) //10레벨마다 증가하는 폭 증가
      {
        costPow += 0.2f;
      }
    }
    ```
  - [골드 증가 수정 진행](#골드-증가-수정(10stage마다)) 
    ```c#
    //UIManager 내용
    if (!EnemyManager.Instance.getExist()) //몬스터 뒤짐
    {
      DataManager.Instance.goldPerTake++; //골드 개수 증가
      break;
    }
    ```
> **<h3>Realization</h3>**
  - Awake
    - 초기화 함수. 가장 먼저 호출
  - OnEnable
    - 게임 오브젝트가 활성화 될때 마다 호출
  - Start
    - 게임 시작 후, 첫번째 프레임 시작전 Update 직전에 한번 호출
  - Update
    - 게임 오브젝트가 활성화 되어 있을때 매 프레임 마다 호출
  - LastUpdate
    - 게임 오브젝트가 활성화 되어 있을대 Update후 매 프레임 마다 호출
  - FixedUpdate
    - 게임 오브젝트가 활성화 되어 있을때, 설정된 고정 시간 주기로 호출
    - 고정시간 간격 : Edit -> ProjectSetting -> Time -> Fixed Timelep
  - OnDisable
    - 게임 오브젝트가 비활성화 될 때 마다 호출
    - Update가 호출되지 않음.
    - 다시 활성화 하면 OnEnable부터 호출됨
  - OnDestroy
    - 게임 오브젝트가 삭제될때 호출
  - Invoke
    - 타이머 대신 유니티의 MonoBehaviour에서 제공 하는 함수
    -  Invoke("함수이름", 시간)
  - InvokeRepeating
    - 최초 실행 시간 설정 이후, 반복 시간 설정이 가능한 함수
    - InvokeRepeating("함수이름", 최초 실행 시간, 반복 실행 시간)
  - CancelInvoke
    - 설정된 Invoke가 모두 취소됨
  - OnTriggerEnter
   - Trigger 속성이 True 게임 오브젝트가 충돌 하는 순간 호출
  - OnTriggerStay
    - Trigger 속성의 오브젝트가 충돌후 충돌 해제가 되기 전까지 매 프레임 마다 호출
  - OnTriggerExit
    - Trigger 속성의 오브젝트가 충돌해제될때 호출
___
## __1.19__
> **<h3>Today Dev Story</h3>**
  - ## 밸런스패치 진행
  - Enemy Hp 패치
    - **EnemyManager**에서 Hp를 관리해주며 Mathf.Pow()를 사용해 기하급수적 증가를 이룸
    - **Enemy**에서 ifdead()가 활성화 되었을때 Hp,MaxHp를 증가시킨다.
    - Boss 잡지 못했을때 **DataManager**에서 DecreaseStage()를 통해 Hp와 fixHp감소
    ```c#
    //EnemyManager.cs
    private float n_Hp = 0f;
    private float HpPow = 0.4f; //제곱비
    ///////////////////////
    public float defineHp()
    {
      n_Hp = DataManager.Instance.Hp;         //시작할때 불러온다.
      if (DataManager.Instance.stage % 10 == 0 && isBoss == false)  //10단위 stage라면 보스 출현
      {
        isBoss = true;
        Debug.Log("@@@@@Boss 출현@@@@@");
      }
      if(DataManager.Instance.stage % 10 == 1)
      {
        DataManager.Instance.subHp = n_Hp;
        Debug.Log("저장" + DataManager.Instance.subHp);
      }
      n_Hp += DataManager.Instance.fixHp * Mathf.Pow(DataManager.Instance.fixHp, HpPow / DataManager.Instance.stage); //수정해야함
      return n_Hp;
    }
    ```
    ```c#
     //Enemy
    public void ifdead()    //일반 몬스터가 죽을때
    {
      r_gold = Random.Range(DataManager.Instance.goldPerTake, DataManager.Instance.goldPerTake + 2);   //+1까지만 지원
      DataManager.Instance.gold += r_gold;    //추후 추가
      DataManager.Instance.stage++;
      EnemyManager.Instance.setExist(false);

      //Hp 관련
      DataManager.Instance.Hp = maxHP;
      DataManager.Instance.fixHp += 5;    //Hp 증가
      Destroy(this.gameObject);
    }
    ```
    ```c#
    //DataManager.cs 
    public float subHp  //보스를 잡지 못했을 때 HP를 줄이기 위한 용도
    {
      get { return PlayerPrefs.GetFloat("subHp", 0f); }
      set { PlayerPrefs.SetFloat("subHp", value); }
    }
    public float fixHp  //5씩 증가하는 계산 용도
    {
      get { return PlayerPrefs.GetFloat("fixHp", 5f); }
      set { PlayerPrefs.SetFloat("fixHp", value); }
    }
    public float Hp //실질적으로 관련
    {
      get { return PlayerPrefs.GetFloat("Hp", 0f); }
      set { PlayerPrefs.SetFloat("Hp", value); }
    }
    /////// -->예외적으로 줄어드는 관리
    public void DecreaseStage()
    {
      stage -= 9; //스테이지 감소

      //몬스터 Hp감소
      Hp = subHp;
      fixHp -= 45;
    }
    ```
  - GUI 수정 
    - <img src="Capture/NGUI.gif" width = 350>
    - 배치수정, 상태표시 창 삭제 // 업그레이드 창에서 현제 상태 확인 가능
> **<h3>Realization</h3>**
  - null
___
## __1.20__
> **<h3>Today Dev Story</h3>**
  - ### 최초 업글시 투명도를 상승시켜 구매한것과 하지 않은것에 대해 구분
    - <img src="Capture/NGUI1.gif" width=350>
    ```c#
    //PowerButton
    private void OnEnable() //오브젝트 활성화시
    {
      if (DataManager.Instance.power != 1)    //투명도 조절위함
      {
        isPurchased = true;
      }
    }

    public override void PurchaseUpgrade()
    {
      //if구문->돈빼고(자동저장)
      if (DataManager.Instance.gold >= currentCost)
      {
        isPurchased = true; //추가
        DataManager.Instance.gold -= currentCost;
        DataManager.Instance.power += costPow;  //수정
        DataManager.Instance.SavePowerButton(this);
        level++;
        if (level % 3 == 0)
        {
          UpdateItem();
        }
        UpdateUI();
        if (level % 10 == 0) //10레벨마다 증가하는 폭 증가
        {
          costPow += 0.2f;
        }
      }
    }
    ```
  - ### AutoClick밸런스
    ```c#
    float startCurrentCost = 10f;
    float UpcostPow = 1.3f;
    float currentCost = 10f;
    int level = 1;
    public void test()
    {
      currentCost = startCurrentCost * Mathf.Pow(UpcostPow, level);
      Debug.Log(level + " : " + currentCost);
      level++;
    }
    ```
> **<h3>Realization</h3>**
  - null
___
## __1.21__
> **<h3>Today Dev Story</h3>**
  - ### AutoClick밸런스 int형으로 진행
  - 몬스터 오브젝트 풀링
    - 진행도중 너무 많은 오류발생 및 관여할일이 많아짐 <ins>(추후 수정)</ins> 
  - 모든 수 소수점 2자리 고정
> **<h3>Realization</h3>**
  - null
___
## __1.22__
> **<h3>Today Dev Story</h3>**
  - 스킬의 객관화(string 사용하여 스킬의 효과를 지정 및 실현)
    ```c#
    //InventoryManager
    public class SlotData
    {
      .
      .
      public string type;         //power인지 critical인지 추가
    }
    ``` 
    - ### 스킬-발동-수정(2.5)
    ```c#
    private void sumPower()    //Power 계산하는법
    {
      //Combo 순서대로 공격
      if (count == inven.slots.Count)
      {
        count = 0;
      }
      if (inven.slots[count].index != 0)    //0이 아닐때만 실행
      {
        skill();
        if(count == 3){
          killTurn();
        }
      }
      n_power = (float)System.Math.Round(n_power, 2); //2자리 수로 고정한다.
    }
    private void skill()        //기본 모션 한방한방에
    {
      switch (inven.slots[count].type)
      {
        case "Power":
          n_power += n_power * inven.slots[count].additionalD;
          Debug.Log("추가 공격력 : " + n_power);
          break;
        case "Critical":
          if (strikePer >= rand)  //크리티컬 공격
          {
            n_power *= 2;  //대안생각하기
            Debug.Log("추가 크리티컬 : " + n_power);
          }
          Debug.Log("추가 크리티컬이나 일반 공격");
          break;
        case "Gold":
          DataManager.Instance.gold += (int)inven.slots[count].additionalD;
          Debug.Log("추가 돈");
          break;
        case "BossTime":
          //BossTime에 추가적요소 추가
          Debug.Log("추가 보스타임");
          break;
        default:
          break;
      }
    }
    private void skillTurn()        //마지막모션에 추가
    {
      if (inven.slots[0].index == 1 && inven.slots[1].index == 2 && inven.slots[2].index == 3)    //못줄이나...?
      {
        n_power += n_power * 3;
        Debug.Log("@@3번째 강화 공격(*3)@@"); //삭제
      }
      else if (inven.slots[0].index == 1 && inven.slots[1].index == 2 && inven.slots[2].index == 4)
      {
        n_power = 99999999;
        Debug.Log("@@3번째 강화 공격(즉살)@@"); //삭제
      }
    }
    ``` 
    ```c#
    //itemAddButton
    public void Add()
    {
      .
      .
      inven.slots[i].type = i_type;
    }
    ``` 
> **<h3>Realization</h3>**
  - null
___
## __1.23__
> **<h3>Today Dev Story</h3>**
  - 콤보 레벨업과 UI구현 (JSON공부)
    - <img src="Capture/ComboUI.gif" width=350>
    - UI는 Update에 넣어 계속 업데이트하게 만들었고, ItemAddButton에 구현
    - 업그레이드 버튼 시 1상승 <ins>(추후 수정)</ins>
    ```c#
    //디스플레이
    public Text display;

    private void Update()
    {
      UpdateUI();
    }
    public void UpdateCost()
    {
      inven.slots[i_index].additionalD = ++i_additionalD;
    }

    public void UpdateUI()
    {
      display.text = "Additional : " + i_additionalD + "\nindex : " + i_index + "\ntype : " + i_type;
    }
    ```
> **<h3>Realization</h3>**
  -  접근자 프로퍼티에 Json을 적용할수없을까? -> 없음 수정해야됌
    - 변수 하나를 더 지정해서 사용하면 어떨까
    - 접근자 프로퍼티는 제2의 중계자로 사용했다. (2021.01.24)
___
## __1.24__
> **<h3>Today Dev Story</h3>**
  - ### <span style = "color:yellow;">__Json</span>을 사용해서 모든 Data 저장__
    - 기존 get,set은 사용하고 그 안에 json을 사용
    - 이제 접근자 프로퍼티는 수단이 된다.
    - 초기에 json 파일이 없을때 오류가 생긴다. 즉 로딩화면을 구현해서 만들어지면 메인화면을 실행하도록 해야겠다. <ins>(추후 수정)</ins> 
    - ### 데이터의-저장-2자리로-수정(21.2.3)
    ```c#
    public float power  //힘
    {
      get
      {
        Load();
        if(playerData.power == 0) //초기값 설정
        {
          playerData.power = 1;
        }
        return playerData.power;
      }
      set
      {
        playerData.power = (float)System.Math.Round(value, 2); //데이터의-저장-2자리로-수정(21.2.3)
        Save();
      }
    }
    ///////저장 및 로드
    void Save()
    {
        string jsonData = JsonUtility.ToJson(playerData,true);
        string path = Path.Combine(Application.dataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
    }
    void Load()
    {
        string path = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);
    }
    ///저장공간
    [System.Serializable]   //직렬화
    public class PlayerData
    {
      public float subHp;
      public float fixHp;
      public float Hp;
      public float power;
      public float AutoC;
      public int gold;
      public int goldPerTake;
      public float criticalPer;
      public float criticalPow;
      public int stage;
    }
    ```  
    ```c#
    //저장 및 로드
    void SaveCost()
    {
      string jsonData = JsonUtility.ToJson(playerDataCost, true);
      string path = Path.Combine(Application.dataPath, "playerDataCost.json");
      File.WriteAllText(path, jsonData);
    }

    public void LoadCost()
    {
      string path = Path.Combine(Application.dataPath, "playerDataCost.json");
      string jsonData = File.ReadAllText(path);
      playerDataCost = JsonUtility.FromJson<PlayerDataCost>(jsonData);
    }

    public void LoadPowerButton(PowerButton powerButton) //power업글 불러오기
    {
      LoadCost();
      powerButton.currentCost = playerDataCost.P_cost;
      powerButton.level = playerDataCost.P_level;
      powerButton.costPow = playerDataCost.P_cost_pow;
    }

    public void SavePowerButton(PowerButton powerButton) //power업글 저장하기
    {
      playerDataCost.P_cost = powerButton.currentCost;
      playerDataCost.P_level = powerButton.level;
      playerDataCost.P_cost_pow = powerButton.costPow;
      SaveCost();
    }

    [System.Serializable]
    public class PlayerDataCost
    {
      //크리티컬 pow
      public int C_cost;
      public int C_level;

      //크리티컬 per
      public int C_P_cost;
      public int C_P_level;

      //파워
      public int P_cost;
      public float P_cost_pow;
      public int P_level;

      //Auto click
      public int A_cost;
      public int A_level;
    }
    ```
  - 콤보 3번째에 오류 발생 (저장 순서 변경) ~~<ins>(추후 수정)</ins>~~
  - cost를 저장하는 것은 오류 (Load) -> 초기에 로드해주니 성공
  - 파일 생성 및 호출의 수정  
    ```c#
    //DataManager.cs
    private void Awake()
    {
      if (!File.Exists("Assets/playerData.json"))    //파일이 없다면 생성 (추후 로딩으로 뺀다.)
      {
        Save();
        SaveCost();
      }
      else
      {
        Load();
        LoadCost();
      }
    }
    //UIManager.cs // 초기화
    public void ResetButton()   //PlayerPrefs 데이터를 모두 삭제
    {
      File.Delete("Assets/playerData.json");
      File.Delete("Assets/playerDataCost.json");
    }
    ```
> **<h3>Realization</h3>**
  - 파일의 생성 및 관리
    ```c#
    File.Create("path");  //파일의 생성
    File.Exists("path");  //파일의 존재 유무
    File.Delete("path");  //파일의 삭제
    ```
  - 폴더의 생성 및 관리 
    ```c#
    Directory.CreateDirectory("path");  //폴더의 생성
    Directory.Exists("path"); //폴더의 존재 유무
    Directory.Delete("path"); //폴더의 삭제
    ```
    - 폴더 안에 파일이 남아 있으면 폴더 삭제가 되지 않는다.(파일 삭제 후 진행)
      ```c#
      string[] allFiles = Directory.GetFiles("Path");
      for(int i =0;i < allFiles.Length; i++){
        File.Delete(allFiles[i]);
      }
      Directory.Delete("path");
      ```
___
## __1.25__
> **<h3>Today Dev Story</h3>**
  - NULL
> **<h3>Realization</h3>**
  - ## <span style = "color:yellow;">ML-Agents</span>
    - [유니티](https://unity3d.com/kr/machine-learning)
    - [학습](https://www.youtube.com/watch?v=twcmguIedhY&list=PLctzObGsrjfwYHL1obWlVdPRbpubkuKWp) 
    - 3D 머신러닝이다. 
  - ## <span style = "color:yellow;">API</span>(Application Programming Interface)
    - 응용프로그램 간에 데이터를 주고받는 방법
      - 서버와 데이터를 주고 받으므로써 응용프로그램을 만들수있다.
      - 인증,호출 제한 (해당 API의 메뉴얼을 읽어봐야한다.)   
      - EX) 카카오API, 페이스북API, 알라딘API.....
    - 미리 만들어 놓은 함수들의 집합
___
## __1.26__
> **<h3>Today Dev Story</h3>**
  - Misson 구현 도중 종료
    - Json의 저장을 어디로 할지 고민중 data? __misson__ 
    ```c#
    //MissonManager.cs  
    private void increased_A()  //미션 A 증가
    {
      if (A_count_max <= A_count)
      {
        Debug.Log("A_count : " + A_count);
        A_count_max += 10;
      }
    }
    ```
  
  - Misson, 스킬다양화(밸런스), 몬스터 오브젝트 풀링,공격 system, GUI 개선, 사운드,이미지, Json으로 데이터저장(combo)
> **<h3>Realization</h3>**
  - 사용자 프러퍼티 사용시 set에서 본인을 리턴한다면 스택오버플로우가 발생한다.
    - 이와 같은 경우는 그 본인은 선언된 변수가 아니라 속성이기 때문에 오류가 발생하는 것이다.   
    - 즉 속성 값에 데이터를 넣어주므로 계속 set이 호출되는 것이다. 
    - json과 활용해서 사용한다면 효율적으로 사용할 수 있다고 생각한다.
___
## __1.27__
> **<h3>Today Dev Story</h3>**
  - Misson 구현 완료
    - 골드 수입까지 구현
    - 앞으로 더 많은 Misson 추가 예정
    - <img src="Capture/Misson.gif" width=350>
    ```c#
    /////////////////////////////
    public Text display_1;
    public CanvasGroup canvasGroup; //투명도 조절을 위함
    private bool isfill = false;
    
    public int A_count  //AttackCount
    {
      get {
        DataManager.Instance.LoadMisson();
        return DataManager.Instance.playerMisson.count;
      }
      set {
        DataManager.Instance.playerMisson.count = value;    //굳이 이렇게?   추후 수정
         DataManager.Instance.SaveMisson();
      }
    }

    private int A_count_max      //AttackCount
    {
      get
      {
        DataManager.Instance.LoadMisson();
        return DataManager.Instance.playerMisson.Max_count;
      }
      set
      {
        DataManager.Instance.playerMisson.Max_count = value;    //굳이 이렇게? 추후 수정
        DataManager.Instance.SaveMisson();
      }
    }

    private int missonGold = 10;    //보상 골드

    private void Start()
    {
        canvasGroup.alpha = 0.4f; //투명도 조절
    }

    private void Update()
    {
      increased_A();
      UpdateUi();
    }

    private void increased_A()  //미션 A 증가
    {
      if (A_count_max <= A_count)
      {
        canvasGroup.alpha = 1.0f;
        isfill = true;
        A_count_max += 10;
      }
    }

    public void getGold()
    {
      if (isfill)
      {
        canvasGroup.alpha = 0.4f;
        isfill = false;
        DataManager.Instance.gold += missonGold;
      }
    }

    private void UpdateUi()
    {
      display_1.text = "Max : " + DataManager.Instance.playerMisson.Max_count + "\ncount : " + DataManager.Instance.playerMisson.count;
    }
    ``` 
  - 이미지 구상 및 실현
> **<h3>Realization</h3>**
  - null
___
## __1.28__
> **<h3>Today Dev Story</h3>**
  - 배경 구하고, 이미지 작성 
> **<h3>Realization</h3>**
  - Git 공부
___
## __1.29__
> **<h3>Today Dev Story</h3>** 
  - Misson 수정
    - MissonManager를 지우고 Missons와 MissonA를 만들어서 Missons를 상속받아 사용
    - 추후 Misson 다양화 및 수정  <ins>(추후수정)</ins> 
    ```c#
    public void OnClick() //AttackButton
    {
      ...
      ...
      ...
      //실질적으로 데미지를 입히고 보여주는 곳
      playerAnimation.AttackAction(count);
      EffectManager.Instance.attckShow();
      missonA.A_count++;  //미션 관련
      Enemy.Instance.decreased(n_power); //추후 수정 --> 싱글톤 삭제하자!n 
      count++;
      
    }
    ```  
    ```c#
    public abstract class Missons : MonoBehaviour
    {
    public Text display;
    public CanvasGroup canvasGroup; //투명도 조절을 위함

    public int missonGold = 10;    //보상 골드

    public abstract void Increased();  //미션 조건 증가

    public abstract void GetGold();     //보상 수여

    public abstract void UpdateUi();    //UI의 갱신
    }
    ```
  - Combo의 Json 저장 및 삭제 구현 (로드는 아직)
    - [콤보 삭제 수정(저장기능)](#Combo-수정)
    ```c#
    //추가
    public void Add()   //추후 오브젝트 풀링으로 변경하자
    {
      for (int i = 0; i < inven.slots.Count; i++)   //빈곳에 넣는다.
      {
        if (inven.slots[i].isEmpty)
        {
          Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
          inven.slots[i].isEmpty = false;
          inven.slots[i].additionalD = i_additionalD; 
          inven.slots[i].index = i_index;
          inven.slots[i].type = i_type;
          inven.slots[i].cost = i_cost;
          switch (i)  //데이터의 저장
          {
            case 0:
              DataManager.Instance.slotSave.index_1 = i_index;
              break;
            case 1:
              DataManager.Instance.slotSave.index_2 = i_index;
              break;
            case 2:
              DataManager.Instance.slotSave.index_3 = i_index;
              break;
            default:
              break;
          }
          DataManager.Instance.SaveSlot();
          break;
        }
      }
    }
    ```  
> **<h3>Realization</h3>**
  - 원하는 오브젝트 찾는 방법(반복되게 사용시 성능 저하발생)
    ```c#
    GameObject.Find("이름");                        //이름
    GameObject.FindWithTag("태그명");               //태그
    GameObject.FindGameObjectWithTag("태그명");     //태그
    ```
  - 상속보다는 <span style = "color:yellow;">컴포넌트 패턴</span>이 더 좋다
    - 유연한 재사용의 가능
    - 기획자의 프로그래머 의존도가 저하
    - 독립성 덕분에 기능 추가와 삭제가 용이 
___
## __1.30__
> **<h3>Today Dev Story</h3>** 
  - combo Json 로드실패
  - 이미지 선택중
  - 모든 panel이 꺼져있을때 오류 방생.... -> 데이터의 저장을 항상 켜져있는곳으로 수정 예정 -> 해당 메뉴 활성화 시 load 
  - 스킬다양화(밸런스), 몬스터 오브젝트 풀링,공격 system, GUI 개선, 사운드,이미지,저장 2자리수
> **<h3>Realization</h3>**
  - MonoBehaviour
    - 유니티의 모든 컴포넌트는 이 클래스를 상속한다. 
  - 메시지 기반 방식
    - 오브젝트를 찾기위해서 메시지를 보낸다.(브로트캐스팅방식)  
  - 스코프
    - 변수의 유효범위
  - 배열 -> int[] a = new int[5]; 
  - 클래스와 오브젝트는 객체지향의 핵심이다.
    - 클래스는 틀, 오브젝트는 사물 
    - 클래스로 만든 변수는 int와 다르게 참조 타입임으로 new를 사용해야한다.
    - 참조타입에 대입시 주소를 바꾸는 것임으로 가비지가 생기지만 값타입인 경우 본체내에 저장하기에 문제가 없다.
___
## __1.31__
> **<h3>Today Dev Story</h3>** 
  - ### Misson의 데이터 저장시 SetActive가 false로 되어 있으면 저장이 되지 않는 오류 발생
    - <img src="Capture/DataSave.png" height=300>
    - 데이터의 저장을 밖으로 빼놨다. 항상 저장이 진행되도록
  - ### combo수정
    - 콤보창을 활성화 할때 로드가 된다. 
    - [콤보 저장 수정](#미션-데이터-수정)
    - Combo창을 키지 않고 시작할때도 로드 되야한다. <ins>(추후 수정)</ins>
    ```c#
    //UIManager
    public void SwitchCombo()    //선택하면 Active를 비/활성화 (Misson창)
    {
      UpgradeP.SetActive(false);
      MasterP.SetActive(false);
      ComboP.SetActive(true);
      MissonP.SetActive(false);
      scrollRect.enabled = false; //스크롤 비활성화
      content.anchoredPosition = new Vector2(0, -100);    //초기로 고정해버림
      inventoryManger.Load();
    }
    ```
    ```c#
    //InventoryManager
    public void Load()  //데이터의 로드
    {
      DataManager.Instance.LoadSlot();    //호출
      for (int i = 0; i < 3; i++)
      {
        switch (i)
        {
          case 0:
            num = DataManager.Instance.slotSave.index_1;
            itemAddButton = GameObject.Find("Add_item" + num).GetComponent<ItemAddButton>();
            itemAddButton.Add();
            break;
          case 1:
            num = DataManager.Instance.slotSave.index_2;
            itemAddButton = GameObject.Find("Add_item" + num).GetComponent<ItemAddButton>();
            itemAddButton.Add();
            break;
          case 2:
            num = DataManager.Instance.slotSave.index_3;
            itemAddButton = GameObject.Find("Add_item" + num).GetComponent<ItemAddButton>();
            itemAddButton.Add();
            break;
          default:
            break;
        }
      }
    }
    ```
  - offsetX를 활용, 배경의 스크롤 수정 진행 <ins>(추후 수정)</ins>
    
    <img src="Capture/After/UIupdate.gif" height = 350>
> **<h3>Realization</h3>**
  - null
___
## __2.01__
> **<h3>Today Dev Story</h3>** 
  - null
> **<h3>Realization</h3>**
  - OnTriggerEnter, OncollisionEnter 2가지로 충돌이 구분
    - OnCollisionEnter (일반 충돌)
      - 일반적인 콜라이더를 가진 두 게임 오브젝트가 충돌할때 실행
      - 충돌시 서로 밀어냄
    - OnTriggerEnter (트리커 충돌)
      - 두 오브젝트 중 하나가 트리거 콜라이더라면 실행
      - 충돌시 그냥 통과     
___
## __2.02__
> **<h3>Today Dev Story</h3>** 
  - null
> **<h3>Realization</h3>**
  - null 
___
## __2.03__
> **<h3>Today Dev Story</h3>** 
  - 플레이 시 Combo창이 활성화 되야만 액션 존재
    - ~~메뉴의 전체를 시작시 1회 비/활성화를 진행~~ 
    - ### Coroutline-수정(2.4일-수정)
      - <span style = "color:yellow;">코루틴 진행 시 성능저하 발생</span>, ~~일반 메서드로 진행~~  
    - ## 삭제된 메서드
      - ### InventoryManager에서-진행  
    ```c#
    //UIManager.cs 
    PowerOnoff(); //start에 존재
    ///////
    void PowerOnOff()
    {
      //켜기
      SwitchUpgrade();
      SwitchMaster();
      SwitchCombo();
      SwitchMisson();
      //끄기
      SwitchUpgrade();
    }
    ``` 
  - [데이터들의 저장을 2자리수로 변환](#데이터의-저장-2자리로-수정(21.2.3))
    
    <img src="Capture/After/DataPoint.png" height=300> 
    
    - float형 모두
    - 그러나 적용이 될때가 있고 안될때가 있다. 
> **<h3>Realization</h3>**
  - Profiler
    - Window - Analysis - Profiler
    - 성능을 알려준다.
___
## __2.04__
> **<h3>Today Dev Story</h3>** 
  - [Combo창활성화 수정](#Coroutline-수정(2.4일-수정))
    - 코루틴은 성능 저하 촉구 (일반 메서드 사용)
    <img src="Capture/After/Profiler.gif" height = 200> 
  - GUI수정
   
    <img src="Capture/After/UIupdate2_4.gif" height = 350>  
  - 카메라를 통한 화면 고정
    - 레터박스 사용 (비율외의 곳은 검은색으로 채움)  
    ```c#
    private void Awake()
    {
      Camera camera = gameObject.GetComponent<Camera>();
      Rect rect = camera.rect;
      float scaleheight = ((float)Screen.width / Screen.height) / ((float)9 / 16);    //내 스마트폰의 기록을 가져온다.
      float scalewidth = 1f / scaleheight;
      if( scaleheight < 1)    //상하로 긴 경우
      {
        rect.height = scaleheight;
        rect.y = (1f - scaleheight) / 2f;
      }
      else        //좌우로 긴 경우
      {
        rect.width = scalewidth;
        rect.x = (1f - scalewidth) / 2f;
      }
      camera.rect = rect;
    }
    ``` 
> **<h3>Realization</h3>**
  - null
___
## __2.05__
> **<h3>Today Dev Story</h3>** 
  - 안드로이드로 구동 테스트 결과 심한 지연 발생
    - Json의 저장파일 오류일 가능성
    - 안드로이드의 Json 공부 예정
  - 때릴때마다 돈이 나오게 할까?
  - [스킬 변화](#스킬-발동-수정(2.5))
> **<h3>Realization</h3>*
  - null
___
## __2.06__
> **<h3>Today Dev Story</h3>** 
  - 일반 평타에 대한 설정값 변경 [어제자와 동일](#스킬-발동-수정(2.5))
  - [Effect의 생성 위치 변경 (EffectManager의 위치로 설정)](#Effect-위치수정)
    - 보기좋게 변경

      <img src="Capture/After/NewEffect.gif" height=350>

> **<h3>Realization</h3>**
  - FindObjectsOfType은 배열로 오브젝트를 반환
    - Find계열의 메서드들은 많은 메모리 소모, 반복문에서 사용하지 않는다.
  - gameObject.Transform.LookAt() 
    - Rocation을 전환   
___
## __2.07__
> **<h3>Today Dev Story</h3>** 
  - InventoryManager의 OnEnable에서 __Combo__ 데이터의 로드를 진행, UpdateCost에서 데이터의 저장을 진행 
    - 데이터가 5가지인데 배열로 하지 못해서 고민중 
    - <ins>(추후 수정)</ins>
  - 스킬 BossTime&Gold 증가 구현  
    - 구체화는 아직
    - <ins>(추후 수정)</ins>
    ```c#
    //UIManager.cs에 isCreasedTime 추가
    public bool isCreasedTime = false;  //시간 증가 콤보 사용 가능할때 변환
    ////
    //AttackButton.cs
    private void Start()
    {
        ...
        ...
        ...
        //skill관련
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    private void skill()        //기본 모션 한방한방에
    {
      switch (inven.slots[count].type)
      {
        case "Power":
          n_power += n_power * inven.slots[count].additionalD;
          break;
        case "Critical":
          if (strikePer >= rand)  //크리티컬 공격
          {
            n_power *= inven.slots[count].additionalD;  //대안생각하기
          }
          else
          {
            Debug.Log("추가 크리티컬이지만 일반 공격");
          }
          break;
        case "Gold":
          DataManager.Instance.gold += (int)inven.slots[count].additionalD;
          break;
        case "BossTime":
          if (uiManager.isCreasedTime)
          {
            uiManager.currentTime += inven.slots[count].additionalD;
            //uiManager.currentTime += 1;
            Debug.Log("추가 보스타임");
          }
          break;
        default:
          break;
      }
    }
    ``` 
> **<h3>Realization</h3>**
  - EventSystem
    - UI관련 오브젝트의 터치,드래그 등 상호작용을 전달하는 역할
    - 수정 및 접근할 필요도 이유도 존재 X 
  - Json의 배열 저장
    - JsonUtility.FromJson<JsonTest[]>(jsonData); --> 사용
      - 해봤으나 적용되지 않음 
    - [Wrapper 사용](https://debuglog.tistory.com/36) 
      - 3시간 정도 해봤으나 구현에 어려움을 겪음... 
    - newtonsoft 사용
___
## __2.08__
> **<h3>Today Dev Story</h3>** 
  - null
> **<h3>Realization</h3>**
  - 텍스트가 잘보이기 위해서 그림자 효과를 추가한다.
    - Add Component > UI > Effects > Shadow
  - 씬 로드
    - SceneManager.LoadScence("씬이름");  
  - 벡터 정규화(방향 벡터)
    - Vector2(3,3)은 방향과 크기가 포함됌, Normalized Vector를 사용하면 방향(1)과 크기를 분리
    - Vector3.normalized
    - <span style = "color:yellow;">목적지 - 현재 위치 = 목적지까지 방향과 거리</span>
  - 내적을 사용하면 두 물체 사이의 각도를 알 수 있다. (Vector3.Dot(a,b))
  - 외적을 사용하면 표면에 수직인 방향을 알 수 있습니다. (노말벡터) (Vector3.Cross(a,b)) 
  - 벡터의 길이 (Vector3.magnitude)
___
## __2.09__
> **<h3>Today Dev Story</h3>** 
  - [구름은 항상 움직이도록 BGScroller 수정](#구름은-항상-움직이게-수정)
  
    <img src="Capture/After/Cloud.gif" height= 250> 

> **<h3>Realization</h3>**
  - None
___
## __2.10__
> **<h3>Today Dev Story</h3>** 
  - Critical Pow 삭제
    - Skill 사용 시 Critical이 적용 되기에 기존 Pow는 삭제 (json 또한) 
  - 초기 Combo 호출 수정 [이전 Combo 호출 방식](#InventoryManager에서-진행)
    - Josn 호출과 로드 성공 기존 존재하던 SlotSave 활용
    - ### 초기값-설정
    ```c#
    private void OnEnable()
    {
      ui = FindObjectOfType<UIManager>();
      ui.SwitchOn();
      for (int i = 1; i <= 5; i++)
      {
        ItemAddButton skill = GameObject.Find("Add_item" + i).GetComponent<ItemAddButton>();
            
        DataManager.Instance.LoadSlot();
        switch (i)  //사실 배열로 받으면 훨씬 짧다.
        {
          case 1:
            if(DataManager.Instance.slotSave.additionalD_1 == 0)    //초기값 설정 (2.12)
            {
              DataManager.Instance.slotSave.additionalD_1 = 0.01f;
            }
            skill.i_additionalD = DataManager.Instance.slotSave.additionalD_1;
            skill.i_level = DataManager.Instance.slotSave.level_1;
            kill.i_cost = DataManager.Instance.slotSave.cost_1;
            break;
          ...
          ...
          ...
          }
        }
      }
    ```
    ```c#
    [System.Serializable]
    public class SlotSave      
    {
      //상단에 들어가는 부분
      public int index_1;
      public int index_2;
      public int index_3;

      //각각 값을 할당해주는곳
      public float additionalD_1;   //추가 데미지
      public int level_1;           //그 Slot의 레벨 값
      public int cost_1;           //그 Slot의 돈

      public float additionalD_2;   //추가 데미지
      public int level_2;           //그 Slot의 레벨 값
      public int cost_2;           //그 Slot의 돈

      ...
      ...
      ...
    }
    ```
  - 이미지 만듦 
> **<h3>Realization</h3>**
  - None
___
## __2.11__
> **<h3>Today Dev Story</h3>** 
  - None
>**<h3>Realization</h3>**
  - None
___
## __2.12__
> **<h3>Today Dev Story</h3>** 
  - [초기 Combo 호출 완벽 수정완료](#시작시-Combo창-활성화-수정(2.12))
    - 이제는 시작 시 자동으로 skill 사용가능 
    - InventoryManager의 OnEnable에서 [skill의 초기값 설정](#초기값-설정) 
  - Json 로컬 주소를 수정
    
    <img src="Capture/After/Before_Encoding.png" height=300 title="암호화 이전"> 

    - Application.dataPath --> Application.persistentDataPath
    - ### 암호화-이전(2.12)
    ```c#
    void Save() //수정 전
      {
        jsonData = JsonUtility.ToJson(playerData, true);
        path = Path.Combine(Application.dataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
      }

    void Save() //수정 후 
      {
        jsonData = JsonUtility.ToJson(playerData, true);
        path = Path.Combine(Application.persistentDataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
      }
    ```
> **<h3>Realization</h3>**
  - [전처리(Preprocessor Directive)](https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/preprocessor-directives/)
    - 컴파일러가 소스코드를 컴파일하기 이전에 전처리기 지시어로 표현된 영역을 미리 처리하는것
    - 항상 #으로 시작 #define(항상 상단에), #if ~ #endif, #ifdef  
      <details>
      <summary>활용 예시</summary>
      <div markdown="1">
    
      - <span style = "color:yellow;">#define</span> <-> <span style = "color:yellow;">#undef</span>(비활성화)
        - 이것을 활용해서 #if ~ #endif를 활용
        - 해당 .cs에서만 사용 가능 --> 프로젝트에 가서 Bulid/General/Conditional symbols에서 심볼을 정의하면 전역에서 사용가능//복수로 사용하고 싶다면 ;를 사용하여 구분한다.
        - 안드로이드나 윈도우 환경을 방향킬르 설정할때 쓸 수 있을듯 
        ```c#
        #define TEST_ENV

        public string GetServer(){
          string server;
        #if (TEST_ENV)
          server = "TESTSERVER";
        #else
          server = "PRODSERVER";
        #endif
          return server;
        }
        ``` 
      - <span style = "color:yellow;">region</span>
        - 일정 코드 영역을 묶는 역할
        - 코드 옆의 -,+를 통해 쉽게 볼 수 있다.
        ```c#
        #region Fields
        private bool debug;
        private string key;
        #region 
        ```
      - <span style = "color:yellow;">warning & error</span>
        - warning은 경고 표시 시 사용 exe파일에는 영향이 없다.
        - error는 오류 표시 시 사용 컴파일이 진행되지 않는다.
        ```c#
        #define ENTER_EDITION

        #if (!ENTER_EDITION)
        #warning This class should be used in ENTER_EDITION
        #error This class should be used in ENTER_EDITION
        #endif
        ```  
      - <span style = "color:yellow;">pragma</span>
        - 일시적으로 경고가 뜨는 부분을 가리고 싶을때  
        - 컴파일러 고유의 전처리기를 나타낼때 표현
        ```c#
        #pragma warning disable //비활성화
          if(false){
            ...
            ...
          }
        #pragma warning restore
        /////에러 코드로 정지하는 방법
        #pragma warning disable 169
        ``` 
      </div>
      </details>
  - json 안드로이드
    - Json 파일 저장 시 로컬 주소를 Application.dataPath & Application.streamingAssetsPath가 아닌 <span style = "color:yellow;">Application.persistentDataPath</span>를 사용한다.
    - 1번은 에디터에서만 사용 가능 하며,2번은 다른 곳에서도 사용 가능 하지만 폴더(Assets/streamingAssets)를 만들어 주어야한다.
    - EX) C:/Users/민식/AppData/LocalLow/namaan/My Clicker Game
  - [내일 들을 것_안드로이드_Json](https://www.youtube.com/watch?v=z-eBBEw8gbw&t=601s)  
    - 7분 30초
___
## __2.13__
> **<h3>Today Dev Story</h3>** 
  - <span style = "color:yellow;">__암호화__</span>

    <img src="Capture/After/After_Encoding.png" height=300 title="암호화 이후"> 

    - 데이터를 바이트 형식으로 반환 후 다시 문자열로 전환 후 저장
    - [json 암호화 이전 코드](#암호화-이전(2.12))
      <details>
      <summary>수정된 코드</summary>
      <div markdown="1">
    
      ```c#
      void Save()
      {
        jsonData = JsonUtility.ToJson(playerData, true);
        path = Path.Combine(Application.persistentDataPath, "playerData.json");
        File.WriteAllText(path, Encoding(jsonData));  //마지막에 암호화
      }

      void Load()
      {
        path = Path.Combine(Application.persistentDataPath, "playerData.json");
        jsonData = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(Decoding(jsonData));  //마지막에 복호화
      }
      ////
      private string Encoding(string jsonData)   //암호화 메서드
      {
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonData);    //바이트로 전환  
        string code = System.Convert.ToBase64String(bytes);             //다시 문자로 전환
        return code;
      }
      private string Decoding(string jsonData)   //복호화 메서드
      {
        byte[] bytes = System.Convert.FromBase64String(jsonData);
        string code = System.Text.Encoding.UTF8.GetString(bytes);
        return code;
      }
      ``` 
      </div>
      </details>
  - 화면 비율 조정
    - 해상도별 앵커 조정필요 (번거로움)
    - 고정 해상도 사용권장
> **<h3>Realization</h3>**
  - null
___
## __2.14__
> **<h3>Today Dev Story</h3>** 
  - ### 로딩
    - 씬의 전환 시 다음 씬에서 사용될 리소스들을 물리적인 저장소에서 읽어와서 메모리에 올린다.
    - LoadScene는 __동기 방식__ 이기 때문에 씬을 다 불러오기 전까지는 다른 작업 불가
    - LoadSceneAsync는 __비동기 방식__ 이기에 작업 도중 다른 작업 겸행가능 
    - <span style = "color:yellow;">Json.cs 생성 후 인스턴스화, 이제 DataManager.cs에서 사용하던 Save()등의 함수는 Json.cs로 옮겨짐</span> 
      - LoadingScene과 MainScene 모두 사용위함
      ```c#
      DataManager.Instance.PlayerData.Stage = 0;  //수정 전
      Json.Instance.PlayerData.Stage = 0;         //수정 후
      ```  
    1. __로딩 씬을 불러들여 다음 씬을 비동기로 호출하는 방법__
        
        <img src="Capture/After/Loading.gif" width=300 title="로딩 구현">  
        <details>
        <summary>코드 보기</summary>
        <div markdown="1">

        ```c#
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using UnityEngine.UI;
        using UnityEngine.SceneManagement;
        using System.IO;

        public class LoadingManager : MonoBehaviour
        {
          [SerializeField]
          string nextScene;

          [SerializeField]
          Image progressBar;

          GameObject Go;
          bool isReady = false;

          AsyncOperation op;  //로딩 진행 상황

          void Start()
          {
            Go = GameObject.Find("Touch");
            StartCoroutine(LoadSceneProcess()); 
          }

          private void FixedUpdate()
          {
          #if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR         //pc의 경우
            if (isReady && Input.GetKeyDown(KeyCode.Space))
            {
              op.allowSceneActivation = true;
            }
          #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE       //phone의 경우
            if (isReady && Input.touchCount != 0)
            {
              op.allowSceneActivation = true;
            }
          #endif
          }

          IEnumerator LoadSceneProcess()
          {
            op = SceneManager.LoadSceneAsync(nextScene);
            op.allowSceneActivation = false;

            float timer = 0f;
            while (!op.isDone)
            {
              if (!File.Exists(Application.persistentDataPath + "/playerData.json"))    //파일의 로드
              {
                Json.Instance.Save();
                Json.Instance.SaveCost();
                Json.Instance.SaveMisson();
                Json.Instance.SaveSlot();
              }
              yield return null;
              if(op.progress < 0.5f)      //로딩  
              {
                progressBar.fillAmount = op.progress;
              }
              else                        //페이크 로딩
              {
                timer += Time.unscaledDeltaTime / 10;
                progressBar.fillAmount = Mathf.Lerp(0.5f, 1f, timer);
                if(progressBar.fillAmount >= 1f)    //완료시
                {
                  Go.GetComponent<Text>().text = "Touch And Play";
                  isReady = true;
                  yield break;
                }
              }
            }
          }
        }
        ``` 
        </div>
        </details> 

      - 전처리문을 통해 UnityEditor와 Android를 구분해서 사용
        - PC는 space바를 Android는 터치를 통해 게임을 시작 
    2. __Scene을 불러오는 것이 아닌 UI로 화면을 가리고 가져오는 방법 (나는 사용X)__
> **<h3>Realization</h3>**
  - 막대 형식을 표현할때 굳이 slider의 사용이 아닌 image를 생성 후 그림과 같이 수정하여 Fill Amount를 조정하여 사용
    
    <img src="Capture/After/NewSlider.png" width=300 title="slider 대용">  
 
___
## __2.15__
> **<h3>Today Dev Story</h3>** 
  - 미션 진행 시 획득 가능한 보상의 수 표시 
  - <img src="Capture/After/MissonReword.gif" width=300 title="미션UI">   
  - __Skill 장착 해제 시에도 기존 유지 되는 문제 해결__
    - iventoryManager 싱글톤화 후 ItemDel에서 초기화 진행
    - [수정전 코드 보기](#Item-Del-수정(2.15))
    - ### 3차-Item-Del-수정전(2.16)
      <details>
      <summary>코드 보기</summary>
      <div markdown="1">

      ```c#
      //ItemDel.cs
      private void FixedUpdate()
      {
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())
        {
          switch (Input.inputString)  //데이터의 삭제
          {
            case "1":
              Json.Instance.slotSave.index_1 = 0;
              SReset(0);
              break;
            case "2":
              Json.Instance.slotSave.index_2 = 0;
              SReset(1);
              break;
            case "3":
              Json.Instance.slotSave.index_3 = 0;
              SReset(2);
              break;
            default:
              break;
          }
          Json.Instance.SaveSlot();
          Destroy(this.gameObject);
        }
      }
      private void SReset(int i)
      {
        InventoryManger.Instance.slots[i].isEmpty = false;
        InventoryManger.Instance.slots[i].additionalD = 0;
        InventoryManger.Instance.slots[i].index = 0;
        InventoryManger.Instance.slots[i].type = null;
        InventoryManger.Instance.slots[i].level = 0;
        InventoryManger.Instance.slots[i].cost = 0;
      }
      ``` 

    </div>
    </details>
  - Find<>함수를 쓰는 부분 수정 (최적화) 
> **<h3>Realization</h3>**
  - 최적화 툴 3가지
___
## __2.16__
> **<h3>Today Dev Story</h3>** 
  - ItemmButton의 삭제를 위해서 버튼으로 구현
    - 클릭한 부모의 이름에서 번호를 추출해 삭제 사용 
    - [이전 코드](#3차-Item-Del-수정전(2.16))
      <details>
      <div markdown="1">

      ```c#
      public void OnClick()
      {
        int i = int.Parse(gameObject.transform.parent.name.Substring(gameObject.transform.parent.name.IndexOf("_") + 1,1));
        switch (i)  //데이터의 삭제
        {
          case 0:
            Json.Instance.slotSave.index_1 = 0;
            SReset(i);
            break;
          case 1:
            Json.Instance.slotSave.index_2 = 0;
            SReset(i);
            break;
          case 2:
            Json.Instance.slotSave.index_3 = 0;
            SReset(i);
            break;
          default:
            break;
        }
        Json.Instance.SaveSlot();
        Destroy(this.gameObject);
      }
      ``` 

    </div>
    </details> 
  - 스크롤이 진행되지 않는 오류 수정
  - Master버튼에서 json 파일의 삭제 되지 않는 오류 수정
> **<h3>Realization</h3>**
  - 각종 오브젝트 호출방법
    ```c#
    gameObject.transform.parent... //부모 객체 호출
    gameObject.GetChild(0).gameObject... //0번째 자식 호출
    gameObject.GetChild(1).gameObject... //1번째 자식 호출
    ///자식 오브젝트를 배열로 가져와 순차적으로 작업 처리시
    Transform[] objList = gameObject.GetComponentsInChildren(typeof(Transform));

    foreach( Transform child in objList )
    {
      child.gameObject.GetComponent( ....);
    }
    ```
  - Raycast
    - RaycastHit를 사용하기 위해선 Collider가 필수
    - UI는 RayCast Target을 활성화 후 사용

___
## __2.17__
> **<h3>Today Dev Story</h3>** 
  - __메인화면 스크롤러는 따로 작성__
    - <img src="Capture/After/Loading2.gif" width=250 title="MainScene"> 
  - __Enemy Hited 이미지 수정__ 
    - 애니메이션이 한번 종료되다면 전환
    - <img src="Capture/After/Hited.gif" width=300 title="EnemyHited">  
      

      ```c#
      //애니메이션이 끝나면 애니메이션 종료(순환 촉구)
      if(ani.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Hited") && ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)    애니메이션
      {
        ani.SetBool("Hited", false);
      }
      ```
  - 모든 UGI 수정 (Player...)
> **<h3>Realization</h3>**
  - null
___
## __2.18__
> **<h3>Today Dev Story</h3>** 
  - DefaultIcon, SplashImage 수정
  - 시작화면과 아이콘 생성 및 적용
    - 등록이 목표가 아니기 때문에 간단히 작성
    - <img src="Capture/After/SplashScreen.gif" width=250 title="Splash"> 
> **<h3>Realization</h3>**
  - null
___
## __2.19__
> **<h3>Today Dev Story</h3>** 
  - GUI수정 
> **<h3>Realization</h3>**
  - null
___
## __2.20__
> **<h3>Today Dev Story</h3>** 
  - GUI수정, 밸런스확인
  - 작은 오류 수정
> **<h3>Realization</h3>**
  - null
___
## __2.21__
> **<h3>Today Dev Story</h3>** 
  - null
>**<h3>Realization</h3>**
  - null 
___
## __2.22__
> **<h3>Today Dev Story</h3>** 
  - UI 추가
    - Sound Mute(PlayerPref사용)
      ```c#
      bool isMuted;
      Animator ani;

      private void Start()
      {
        ani = gameObject.GetComponent<Animator>();
        isMuted = PlayerPrefs.GetInt("Muted") == 1;     //bool 값이기 때문에
        ani.SetBool("isOn", !isMuted);                  //Animator추가
        AudioListener.pause = isMuted;
      }

      public void MutePressed()   //클릭시
      {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        ani.SetBool("isOn", !isMuted);
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
      }
      ``` 
> **<h3>Realization</h3>**
  - null
___
## __2.23__
> **<h3>Today Dev Story</h3>** 
  - 사운드 개선
    - 공격시 , 이동시, 코인 사용시
    - AttackButton에 사운드추가
      ```c#
      soundManager.SoundPlay(inven.slots[count].index);
      //////////////////////
      public void SoundPlay(int num)  //index 들어온다.
      {
        switch (num)
        {
          case 1:
            sound[num - 1].Play();
            break;
          case 2:
            sound[num - 1].Play();
            break;
          case 3:
            sound[num - 1].Play();
            break;
          case 4:
            sound[num - 1].Play();
            break;
          case 5:
            sound[num - 1].Play();
            break;
          default:
            break;
        }
      }
      ``` 
  - Gold 평타시 50퍼의 확률로 획득
  - 게임설명
    - 캡쳐, ReadMeFile 작성 
> **<h3>Realization</h3>**
  - null 