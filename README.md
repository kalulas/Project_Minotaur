# ProjectMinotaur
Project Minotaur 设计思路

人物和怪物做一个实时的图层排序 ok

场景中不靠边的部件也要图层排序 ok

人物/怪物攻击时调用攻击区，受击区trigger，地形区非trigger，人物和怪物没有地形碰撞 ok

**碰撞体分为三个区**：攻击区（实体） 受击区（触发） 地形区（实体）

受击区现在是对象变量(object)，角色以及攻击碰撞是场景变量(scene)



**实现过程**

加入图层排序→碰撞三个区（**完成**）

→受击的后退与重量（**完成**）

→攻击力与血量（需要一个受击死亡动画过度 **完成**/怪物受击修改**完成**）

→怪物死亡后处理（**完成**）

→玩家死亡处理（**差个UI**现在会在一段时间后重启游戏）

→怪物AI（**巡逻完成**，**追击，放弃追击**，TODO攻击决定）

→场景→新怪→UI

（有余力）→音效→怪物掉落



\*设计碰撞检测，现在把天花板设为Foreground layer

\*注意状态图中的update模块

\*状态机里加状态机要谨慎

\*建议小障碍物的sprite分离viot设在底部



**新建怪物的流程↓**

sprite动画 动画状态机 初始必要的几个object属性

碰撞层monster tag设置needsort

放到中间层，加上相对命名格式的三个碰撞体collider

**怪物object属性** 

1. 被击碰撞区 AttackedCollider GameObject  
2. 运动 Movement Vector2
3. 攻击 Attack float
4. 血量 Health float
5. 速度 Speed float
6. 索敌距离 EyeSight float
7. 反应时间 Reflection float
8. \*重置位置 暂定用于靠墙恢复位置 ResetPosition

**玩家** 攻击5（有/2效应） 血量25 速度0.5

**史莱姆** 攻击2 血量10 速度0.1 反应时间 0.5 索敌距离0.5 可选范围∈(0, 1]

**场景Scene属性**

冲击力AttackForce 50
