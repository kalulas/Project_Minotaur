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

→怪物AI（巡逻，追击，放弃追击，攻击决定**完成**）

→场景{ **TODO**

切换场景的脚本

按F互动脚本 ->衍生掉落道具（bool决定交互是否掉落）

->衍生限制互动（如有钥匙才能和门互动）

->衍生取消碰撞区（如栅栏 **完成**

场景间保存玩家信息脚本（？）

碰触使用道具脚本

}

→新怪→BGM→UI

（有余力）→音效→怪物掉落



\*设计碰撞检测，现在把天花板设为Foreground layer

\*注意状态图中的update模块

\*状态机里加状态机要谨慎

*试一下墙壁检测能不能改进

*怪物受击有点BUG不过我改不动了

\* **人为什么会被打进墙里面？？？**

\*建议小障碍物的sprite分离viot设在底部



**新建怪物的流程**

sprite动画 动画状态机 初始必要的几个object属性

碰撞层monster tag设置needsort

放到中间层，加上相对命名格式的三个碰撞体collider

**怪物object属性** 

1. 被击碰撞区 AttackedCollider GameObject  
2. 攻击碰撞区 AttackCollider GameObject
3. 运动 Movement Vector2
4. 攻击 Attack float
5. 血量 Health float
6. 速度 Speed float
7. 索敌距离 EyeSight float
8. 反应时间 Reflection float
9. 仇恨类型 Follow bool（是否放弃追击
10. \*重置位置 暂定用于靠墙恢复位置 ResetPosition

**TODO：**尝试一下ResetPosition属性能不能自动保存



**玩家** 攻击5（有/2效应） 血量25 速度0.5

**史莱姆** 攻击2 血量10 速度0.1 反应时间 0.5 索敌距离0.5 可选范围∈(0, 1]



**场景Scene属性**

冲击力AttackForce 50
