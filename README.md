# Cookie 핵심기능 
개인 과제 제출용

## 도넛과 코인  

먼저 Donut Click에서 OnMouseDown()을 이용하여 오브젝트 클릭시 Donut Handle의 OnClickedDonut을 실행시키도록 하였습니다 

OnClickedDonut 에서는 도넛의 체력을 감소시킨 후 일정 주기(클릭 횟수) 마다 추가로 체력 감소가 이루어지도록 하였고 

파괴될 경우 OnDestroyDonut()를 파괴 애니메이션 마지막에 이벤트로 두어 리워드를 생성하고 새로운 도넛을 만들어 줍니다

생성된 리워드는 해당하는 리워드 ui쪽으로 이동하여 충돌 후 사라집니다, "Dotween"과 "UIPositionSo" 를 이용하였습니다   

## UI

스코어와 코인 모두 MVP 패턴을 적용해보았습니다, 제대로 한 것인지는 모르겠으나 

View에서는 리워드 오브젝트와의 충돌이 일어났을때 presenter의 addCoin을 실행 시켜주고 

실행되고나면 Model의 coinQuantity를 증가 시켜준후 UI를 Refresh하고 Dotween의 DOScale을 이용하여 이펙트를 주었습니다 

## 오브젝트 풀(UI)

도넛과 코인 두 가지의 풀을 만들어 도넛이 파괴될때 생성하되도록 하였습니다, 오브젝트 생성시 의존성 주입을 통해 결합도를 낮추어 보았습니다
