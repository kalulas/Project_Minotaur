# 三分钟就能完成的米诺陶领风格简易地牢
Project Minotaur 设计思路



### **实现过程**

加入图层排序（**完成**）

→碰撞三个区（**完成**）

→受击的后退与重量（**完成**）

→攻击力与血量（需要一个受击死亡动画过度 **完成**/怪物受击修改**完成**）

→怪物死亡后处理（**完成**）

→玩家死亡处理（**完成**）

→怪物AI（巡逻，追击，放弃追击，攻击决定**完成**）

→场景

​	切换场景的脚本 **完成**

​	切换场景的位置保存 **完成**

​	场景间保存玩家信息脚本（需要保存血量，攻击力 **完成** 

​	按F互动脚本 **完成** 

​	->衍生掉落道具

​		*道具的脚本：被触碰时使用，做成prefab **完成**

​		*道具掉落的同一脚本可以用来做怪物的道具掉落，死亡时触发即可，为怪物添加一个携带Object

​	->衍生限制互动（如有钥匙才能和门互动 请将门命名带Gate **完成**

​	->衍生取消碰撞区（如栅栏 **完成**

->UI 

​	血量和道具文字显示 **完成**

​	字幕淡出效果 **完成**

​	简易血条及携带物品提示 **完成**

→新怪(添加了**哥布林** **米诺陶** **骷髅** **装甲哥布林**)

→BGM

​	关卡1 - 1.5：borderlands-2-ust-tiny-tina-mines-of-avarice-ambient

​	开启陷阱：borderlands-2-ust-tiny-tina-mines-of-avarice-ambient 加速

​	Boss：borderlands-2-ust-tiny-tina-hatreds-shadow-combat

​	通关：Whitney Houston - I Will Always Love You 00_03_08-00_04_33

​	死亡：Tower of Power - So Very Hard To Go (LP Version)

→音效 **大概是不做了**



### 设计要点和注意事项

人物/怪物攻击时调用攻击区，受击区trigger，地形区非trigger，人物和怪物没有地形碰撞 ok

**碰撞体分为三个区**：攻击区（触发） 受击区（触发） 地形区（实体）

\***设计碰撞检测，现在把天花板设为Foreground layer**

***设计交互检测，现在所有道具layer设为Item**

\*注意状态图中的update模块， 状态机里加状态机要谨慎

*试一下墙壁检测能不能改进

*怪物受击有点BUG不过我改不动了 **改好了啊哈哈哈哈哈**

\* **人为什么会被打进墙里面？？？** 

\*<font color=red>**建议所有需要需要排序的sprite分离viot设在底部**</font>

*2018/12/15 修改了人物的viot现在和米诺陶战斗不会怪怪的

2018/12/18/人物死亡后不会被鞭尸 & 怪物不会继续追击 **完成**



### **怪物的生产流程**

sprite动画 动画状态机 初始必要的object属性

tag设置needsort layer设置monster

放到中间层in the middle，加上相对命名格式的三个碰撞体collider



### **怪物属性** 

1. 被击碰撞区 AttackedCollider GameObject  
2. 攻击碰撞区 AttackCollider GameObject
3. 运动 Movement Vector2
4. 攻击 Attack float
5. 血量 Health float
6. 速度 Speed float
7. 索敌距离 EyeSight float
8. 反应时间 Reflection float
9. 是否追击 Follow bool
10. 是否携带物品 CarryItem bool
11. 所携带物品 CarriedItem GameObject
12. 脚本用 StopMoving bool



### **数值属性**

|    类型    | 攻击 | 血量 | 速度 | 索敌距离 | 反应时间 | 是否跟随 |
| :--------: | :--: | :--: | :--: | :------: | :------: | :------: |
|    玩家    |  5   |  25  | 0.5  |    -     |    -     |    -     |
|   史莱姆   |  2   |  10  | 0.1  |   0.5    |   0.5    |    no    |
|   哥布林   |  4   |  15  | 0.3  |    1     |   0.1    |    no    |
| 装甲哥布林 |  5   |  30  | 0.15 |    1     |   0.1    |    no    |
|    骷髅    |  7   |  7   | 0.5  |    1     |   0.2    |    no    |
|   米诺陶   |  8   |  57  | 0.1  |    1     |   0.2    |   yes    |



**场景变量**

Player 玩家，一般用于获得位置

PlayerAttack 玩家攻击碰撞区

PlayerAttacked 玩家受击碰撞区

ForegroundCelling 用于怪物的边缘检测

GameNotice 游戏中的通知栏，用于道具交互，效果提示

SceneResetPosition 为每个场景保存的怪物移动复原位置

GameOver 玩家生命耗尽死亡



**应用变量**

AttackForce 冲击力 50

PlayerHealth 切换场景保存血量

PlayerAttack 切换场景保存攻击力 可能因为药水上升

PlayerHealthMax 玩家允许最大血量

PlayerGotKey 玩家是否持有钥匙 本次设计中钥匙为场景占有

ChangeSceneSituation 玩家从哪一个场景进入哪一个场景，用于位置调整

GameClear 通关！