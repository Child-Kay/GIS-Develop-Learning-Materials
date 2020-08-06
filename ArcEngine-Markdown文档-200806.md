# *ArcEngine

+ 接口编程

  定义一个IPeople using System；（接口有一个性别的方法）

  ![image-20200806105910075](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806105910075.png)

  在接口中，只有方法，没有方法的内容，定义两个类，分别实现接口

   ![image-20200806110006098](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806110006098.png)

![image-20200806110036462](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806110036462.png)

​		一个接口可以被多个类实现；

​		 ![image-20200806110102205](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806110102205.png)

+ OMD

  ![image-20200806110155428](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806110155428.png)

  ​	**1.类和对象**

  在 UML 图中有三种类型的类：抽象类（abstract class）、组件类（CO class）与普通类（instantiable class）。 抽象类：不能创建或实例化，从来没有一个抽象类的实例用于定义子类的公共接口，创建实例的任务由其 子类完成。子类继承其定义的接口。 OMD 符号为：二维的内部有阴影的矩形。 普通类：不能创建，从别的对象获得实例。 OMD 符号为：3D 矩形内部没有阴影。 组件类：可以直接创建实例的类，在 C#中，用 New 关键字。 OMD 符号为：带阴影的 3D 矩形符号。

  ​	**2.关联**

  ​		![image-20200806110309060](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806110309060.png)

  ​	用于多重性关联的符号：

  ​	![image-20200806110326754](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806110326754.png)

![image-20200806110335096](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806110335096.png)

​		**类继承（type inheritance）定义了专门的类，它们拥有超类的属性和方法，并且同时也有自身的属性和方法。**![image-20200806110620964](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806110620964.png)

​		**实例化（Instantiation）指定一个类的对象有这样的方法，它能够创建另外一个类的对象。****

​					![image-20200806110549246](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806110549246.png)

​		**聚合（Aggregation）是一种不对称的关联方式，在这种方式下一个类的对象被认为是一个“整体”，而 另一个类的对象被认为是“部件”。**

![image-20200806110736728](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806110736728.png)

​		组成（Composition）是一种更为强壮的聚合方式，此种方式下，“整体”对象控制着“部分”对象的生存 时间。

![image-20200806110751477](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806110751477.png)

![image-20200806110757008](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806110757008.png)

+ **属性和方法**

![image-20200806110814529](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806110814529.png)

+ **类与接口**

ArcObjcets 中有三类 class， 分别是抽象类（AbstractClass）、组件类（CoClass）和普通类（Class）。抽象类的主要目的是为它的子类定 义公共接口，一个抽象类将把它的部分或全部实现延迟到子类中，因此，一个抽象类不能被实例化。一个 组件类对象可以被直接创建，普通类对象虽然不能直接创建，但它可以可以作为其它类的一个属性或者从 其它类的实例化来创建。

**接口和类接口定义了一组方法和属性**

在 ArcObjects 中接口名称都以”I”开始，如 IMap， Ilayer 等

 AO 开发的时候，和对象间的通信是 通过接口完成的

+ **接口查询**

  一个类可以有多个接口，声明了接口变量并且指向一个对象的时候，这个变量只能使用该接口内的方法和属性，而不能访问其他接口中的方法和属性

  ![image-20200806110951716](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806110951716.png)

+ **类之间的接口类型的继承**

  类类型继承类型继承是指类之间的接口类型的继承，而不是继承其实现继承过来的接口只是名 称相同，具体的实现则不同。

  比如 ShpfileWorkspaceFactry 和 AccessWorkspaceFactry 都继承 WorkspaceFactry， 而他们的打开（OpenFromFile）方法却不一样，ShpfileWorkspaceFactry 的（OpenFromFile）方法需要一个文件目录位置作为参数，而 AccessWorkspaceFactry 的（OpenFromFile）方法需要一个数据库（mdb）位置 作为参数

+ **接口继承**

  接口继承如 ImapFrame 接口和 IMapSurroundFrame 接口继承	于 IFrameElement 接口，则父类接口IFrameElement 所具有的方法	和属性对派生接口 ImapFrame 和 IMapSurroundFrame 都有效。

+ **QI**

  QI 要解 决的就是一个类实现多个接口的问题

  例：

  ![image-20200806111150462](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111150462.png)

![image-20200806111154653](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111154653.png)

​	然后定义了一个 Cat 的类实现这里面的方法：

![image-20200806111201312](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111201312.png)

![image-20200806111228558](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111228558.png)

+ **添加许可控件**

![image-20200806111256221](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111256221.png)

​		AxMapControl 就是 Map 地图控件，AxPageLayouControl 是布局地图控件，AxTOCControl 是目录控件，AxToolbarControl 是 GIS 工具栏控件，AxSceneControl 是 Scene 三维场景 控件，axGlobeControl 是 Globe 控件，AxLicenseControl 是许可控件，AxSymbologyControl 是符号选择器控件， AxArcReaderControl 是 ArcReader 控件，AxArcReaderGlobeControl 是 ArcReaderGlobe 控件。

AxLicenseControl 是许可控件，一般 GIS 系统中都必须添加，否则无法使用。将刚才的窗体的名称改为 Engine.

+ 打开Mxd文件

  ![image-20200806111342267](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111342267.png)

+ 打开shape文件

  ![image-20200806111357164](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111357164.png)

+ 控件功能识别

  MapControl 控件和 PageLayoutControl 控件分别对应于 ArcMap 中的数据视图和布 局视图，MapControl 控件主要用于空间数据的显示和分析，它封装了地图对象，而 PageLayoutControl 控件 是用于地图的修饰和整理，可以用来生成专题图等，它封装了 PageLayout 对象。

  TOCControl 控件和 ToolbarControl 控件分别对应 ArcMap 中的 Table of Contents 控件和工具条控件，这 两个控件都有一个 buddy 属性，这两个控件需要和一个伙伴空间协同工作，伙伴控件可以是 MapControl， PageLayoutContro，SceneControl 或者 globeControl 控件。

  ![image-20200806111426111](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111426111.png)

+ TOCControl控件

  TOCControl 控件使用的是用伙伴控件中的数据地图，它控制图层是否在伙伴控件空显示以及和伙伴控 件在符号上保持一致，TOCControl 为用户提供了一个交互式的环境，如果 TOCControl 控件的伙伴控件是 MapControl 控件，当我们将 TOCControl 控件中图层删掉是，MapControl 控件中相应的图层也会被删掉。![image-20200806111455189](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111455189.png)

ArcGIS Engine 提供的 TOCControl 控件几乎没有提供，那么这些都是需要自己开发的，在这里我做一个 显示属性表的功能。

要显示某一个图层的属性表，首先要将这个图层选中，然后在另外一个 Form 中将选中的这个图层 的属性信息进行显示。

添加一个上下文菜单，添加一个新的 Form 窗体，在这个新的窗体上添加 GridView 控件，并在 TOCControl 控件的 OnMouseDown 事件下添加如下代码（pGlobalFeatureLayer 是我定义的一个全局变量）：

![image-20200806111508165](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111508165.png)

在上下文菜单的打开属性表的 Click 事件中添加如下代码：![image-20200806111520055](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111520055.png)

在新的窗体中添加一个将属性表显示到 GridView 控件中的函数，如下 

![image-20200806111532072](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111532072.png)

![image-20200806111538821](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111538821.png)

+ ToolBarControl控件

  在 ToolBarControl 控件中，我们通过 ToolBarControl 控件的属性页面添加了一些如打开文档，平移，放 大等功能，在 ArcGIS Engine 中我们将宿主在 ToolBarControl 控件中的内容分为三类“命令，工具，工具控 件“。

  

  如果我们点击了平移这个操作，那么这个时候我们还要用鼠标和地图进行平移等交互，那和谁交互呢，我们知道 ToolBarControl 有一个 buddy 属，这个就体现了在 buddy 属性上。ToolbarControl 会将伙伴控件的 CurrentTool 属性设置为我们用鼠标点击的工具，然后伙伴控件就等着和我们的工具交互。工具控件，这通 常是用户界面组件，如 ToolBarControl 控件上的列表框和组合框。其实在 ToolBarControl 控件中还可以宿主 工具条菜单（ToolbarMenu），工具条菜单表示单击命令项的一个垂直列表。用户必须选择工具条菜单上的 一个命令项，或单击工具条菜单之外的地方使其消失。工具条菜单只能驻留命令项(不允许驻留工具或者工 具控件)

  当用户单击这个命令时会导致 ICommand.OnClick 方法被调用，并执行某种操作。要将一个命令宿主到ToolBarControl 控件上，有以下三种方法：

  + 使用UID

  + 使用progID

  + 使用ICommand

    UID pUID = new UIDClass ();
    pUID.Value = "esriControls.ControlsUndoCommand";
    axToolbarControl1.AddItem (pUID, - 1, 0, false, - 1, esriCommandStyles.esriCommandStyleIconOnly);
    axEditorToolbar.AddItem ("esriControls.ControlsUndoCommand", 0, - 1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);

    ICommand pUndo = new ControlsUndoCommandClass ();
    axEditorToolbar.AddItem (pUndo, 0, - 1,false, 0,esriCommandStyles.esriCommandStyleIconOnly);

    

  我们知道宿主在 ToolBarControl 上的命令操作的对象是 ToolBarControl 的伙伴控件，但是，这个命令怎么和 这个伙伴控件联系起来了，注意到 ICommand 接口中有一个 ICommand.OnCreate 方法，这个方法有一个参 数 hook。

  ![image-20200806111744461](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111744461.png)

+ MapControl控件与PageLayOut控件的联动

  要实现这两个控件的联动，我们首先回顾下 ArcMap 中的情景，两个控件的联动不仅仅是简单 的切换，在切换的时候还因该保留各自控件上的一些状态，比如说当我们在 MapControl 上有一个放大操作 时，当我们没有将这个放大操作取消而切换到 PageLayout 控件，在 PageLayout 控件上做了一些操作后，又 切换到 MapControl 控件，我们应该还应该能进行放大操作而不用重新使用放大这个工具。

  通过分析我们可以得到下面几点：

  + § 当切换两个控件的时候，地图的同步

  + § 各自控件上激活的工具或者命令的保留

  + § 当存在 TOC 控件和 ToolBar 控件的时候，切换了地图控件和布局控件，那么这两个控件的伙伴控 件也应发生变化。

    

    在 Form 中添加 TabControl 控件，分别将地图控件和布局控件放置到里面，如下图所示：

![image-20200806111933964](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111933964.png)

​			我们在 NET 中定义一个类，这个类用来实现这两个功能，类的名称是 ControlsSynchronizer![image-20200806111952215](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111952215.png)

![image-20200806111958829](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806111958829.png)

![image-20200806112003761](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806112003761.png)

![image-20200806112009392](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806112009392.png)

![image-20200806112015823](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806112015823.png)

![image-20200806112021510](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806112021510.png)

![image-20200806112026760](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806112026760.png)

在打开地图的时候, 我们只不过是将这个地图付给 了 Map 控件, 这样的话布局控件是得不到图的, 因此应该对 OnClick 改动下, 在这个里面将 map 控件和布 局控件同步起来![image-20200806112039709](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806112039709.png)

![image-20200806112044913](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806112044913.png)

![image-20200806112050584](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806112050584.png)

+ **Map对象**

  在 ArcMap 中，可以显示在 Map 中的数据有两大类，也就是地理数据和图形元素，空间数据是 GIS 分 析制图的数据源，保存在地理数据库库或者 Shp 文件中，图形元素也是一种可以在 Map 上显示的对象。他 们两个的共同特征是拥有一个 geomtry 属性。地图对象是地图数据的容器，它由图层和图形数据组成。Map 对象实现了众多的接口

![image-20200806112119077](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200806112119077.png)