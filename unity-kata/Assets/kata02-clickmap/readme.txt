���⣺ʵ�ָ��������еĲ������ͼ�����ɫ

2019.7.1
�Լ��볢����shaderʵ��

���ʧ�ܣ��ο���������ɶ������Ƭ����ʵ��

ʵ�ָ������������Ŀɵ����ͼ��һ��
https://gameinstitute.qq.com/community/detail/119866
ʵ�ָ������������Ŀɵ����ͼ������
https://gameinstitute.qq.com/community/detail/119904
ʵ�ָ������������Ŀɵ����ͼ������
https://gameinstitute.qq.com/community/detail/120344
ʵ�ָ������������Ŀɵ����ͼ���ģ�
https://gameinstitute.qq.com/community/detail/126898
ʵ�ָ������������Ŀɵ����ͼ������Ԥ�棩
https://gameinstitute.qq.com/community/detail/125595

2019.7.2
ʵ��demo

���⣺
- �����������ж�
	- ͼƬ�ߴ�д���ڴ�����
	- ѡ��Ч��ֻ֧�ָı�͸���ȣ���Ϊ�ȽϺ�ʵ�֣�����֧�ָı���ɫ������������Ч��
	- shader����
		- ʹ���� if-else if
		- �ж���ɫ��ȷǳ���neat

ʵ��Ҫ�㣺
- ��� EventTrigger �Ļص�����Ӧ����¼��ͻ�ȡ���λ��
- ͼƬ�� Import Settings
	- ��ѡ Read/Write Enabled ����ΪҪ��ȡ���ص���ɫ��
	- Filter Mode ѡ�� Point(no filter) �������Ե��ɫ�ı䣬�޷���ʶ��
- ��д shader
	- [HideInInspector]����
	- ��͸����
		- "Queue"="Transparent"
		- "RenderType"="Transparent"
		- Blend SrcAlpha OneMinusSrcAlpha

˼����
- ���Բ����ɰ��rgbͨ������λ�����ɫ��ȵ��жϣ����֧��32λ��RGBA�������ڳ���32���ؿ飬������Ҫ�����ɰ�ͼ����neat����
- �Աȼ�������
	- ����������ɫ�жϣ��������������Դ������򵥣�Ч�����ޣ���Ҫshader֧��
	- �������Ƭ��ײ�������������������Դ�����븴�ӣ���ҪԤ������ģ����Դ��ռ�ÿռ䣩��Ч����Զ�Ԫ����Ҫshader֧��
	- �ɰ�ͼƬ����Ҫ�������������ɰ�ͼ������򵥣�Ч����Զ�Ԫ����Ҫshader֧��
	- ����ѡ��ʲô��������Ҫ�Ӿ����������
	
�Ժ��뵽���õİ취�ٲ���
TBC


��չ������shader��ʹ�� if-else if

���ۣ�
- if-else if / for / while �ȷ�֧������Ƶ�ָ����ת�������ˮ��ͣ��
- ��shader�еķ�֧�ֳɣ�
	- �����������ڳ���
		- ����������ֱ��̯ƽ��֧������չ����unloop��
		- ����For��˵�����и�Ȩ�⣬���For�Ĵ����ر�࣬����body�ڵĴ����ر𳤣����ܾͲ�չ���ˣ���Ϊ��ָ��װ��Ҳ�����޻����кķѵ�
		- ����ɱ����Ժ��Բ���
	- �����������ڳ�����Uniform����
		- ��̬����-->��̬��֧
		- һ�������ڹ̶�����ת��䣬��Ԥ��
		- ͬһ��Warp������micro thread��ִ����ͬ��֧
		- �����������Ż�
		- ������������
		- ����ɱ��ܵͣ�����
	- ����Ϊ��̬���ʽ
		- ��̬����-->��̬��֧
		- �����һ��Warp��Micro Thread֮�������Ҫ�߲�ͬ��֧������
		- ������ֻ��������ʱ��runtime����֪����С��gpu��������branching��������gpu�޷��������ͬʱ���㣬�ֶ�μ��㣬���Ҵ��д���"warp"�͸������ݵĿ������Ƕ��Ե�

- step() �� if-else if Ч��һ��������������
- ���Բ��� float a = b > c ? d : e; ���Ż�


�ο���
Using if-else statements in shaders; how complex is bad?
https://forum.unity.com/threads/using-if-else-statements-in-shaders-how-complex-is-bad.602902/

shader����for��if���������Ϊʲô��ʹ��֡�ʽ��ͺܶࣿ
https://www.zhihu.com/question/27084107

does-if-statements-slow-down-my-shader
https://stackoverflow.com/questions/37827216/does-if-statements-slow-down-my-shader


TODO:
��չѧϰ��GPU warp /wavefront GPUͬʱ������С����

