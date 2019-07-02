主题：实现钢铁雄心中的不规则地图点击变色

2019.7.1
自己想尝试用shader实现

如果失败，参考下面的生成多边形面片方法实现

实现钢铁雄心那样的可点击地图（一）
https://gameinstitute.qq.com/community/detail/119866
实现钢铁雄心那样的可点击地图（二）
https://gameinstitute.qq.com/community/detail/119904
实现钢铁雄心那样的可点击地图（三）
https://gameinstitute.qq.com/community/detail/120344
实现钢铁雄心那样的可点击地图（四）
https://gameinstitute.qq.com/community/detail/126898
实现钢铁雄心那样的可点击地图（更新预告）
https://gameinstitute.qq.com/community/detail/125595

2019.7.2
实现demo

问题：
- 基于像素做判断
	- 图片尺寸写死在代码里
	- 选中效果只支持改变透明度（因为比较好实现），不支持改变颜色或者其他复杂效果
	- shader性能
		- 使用了 if-else if
		- 判断颜色相等非常不neat

实现要点：
- 添加 EventTrigger 的回调，响应点击事件和获取点击位置
- 图片的 Import Settings
	- 勾选 Read/Write Enabled （因为要读取像素点颜色）
	- Filter Mode 选择 Point(no filter) （否则边缘颜色改变，无法被识别）
- 编写 shader
	- [HideInInspector]属性
	- 打开透明度
		- "Queue"="Transparent"
		- "RenderType"="Transparent"
		- Blend SrcAlpha OneMinusSrcAlpha

思考：
- 可以采用蒙版的rgb通道，用位与简化颜色相等的判断，最大支持32位（RGBA），对于超出32个地块，可能需要多张蒙版图（不neat！）
- 对比几种做法
	- 采用像素颜色判断：无需额外美术资源；代码简单；效果有限；需要shader支持
	- 多边形面片碰撞：无需额外制作美术资源；代码复杂，需要预先生成模型资源（占用空间）；效果相对多元；需要shader支持
	- 蒙版图片：需要额外制作美术蒙版图；代码简单；效果相对多元；需要shader支持
	- 最终选择什么方案还是要视具体需求而定
	
以后想到更好的办法再补充
TBC


拓展：关于shader中使用 if-else if

结论：
- if-else if / for / while 等分支语句会设计到指令跳转，造成流水线停滞
- 在shader中的分支分成：
	- 仅依赖编译期常数
		- 编译器可以直接摊平分支，或者展开（unloop）
		- 对于For来说，会有个权衡，如果For的次数特别多，或者body内的代码特别长，可能就不展开了，因为会指令装载也是有限或者有耗费的
		- 额外成本可以忽略不计
	- 仅依赖编译期常数和Uniform变量
		- 静态条件-->静态分支
		- 一个运行期固定的跳转语句，可预测
		- 同一个Warp内所有micro thread均执行相同分支
		- 编译器可以优化
		- 进行批量计算
		- 额外成本很低，良性
	- 条件为动态表达式
		- 动态条件-->动态分支
		- 会存在一个Warp的Micro Thread之间各自需要走不同分支的问题
		- 编译器只有在运行时（runtime）才知道大小，gpu做分批（branching），导致gpu无法最大化利用同时计算，分多次计算，并且带有创建"warp"和复制数据的开销，是恶性的

- step() 和 if-else if 效果一样，并不能提升
- 可以采用 float a = b > c ? d : e; 来优化


参考：
Using if-else statements in shaders; how complex is bad?
https://forum.unity.com/threads/using-if-else-statements-in-shaders-how-complex-is-bad.602902/

shader中用for，if等条件语句为什么会使得帧率降低很多？
https://www.zhihu.com/question/27084107

does-if-statements-slow-down-my-shader
https://stackoverflow.com/questions/37827216/does-if-statements-slow-down-my-shader


TODO:
拓展学习：GPU warp /wavefront GPU同时并行最小计算

