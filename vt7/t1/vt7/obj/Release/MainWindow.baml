   M S B A M L   `   `   `  ���� >  :vt7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:vt7vt7      vt7.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     #localclr-namespace:vt7     -     �Name$  window�� � Title$ 
MainWindow��$	��350��$	��525�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$ ApplicationCommands.Print��.��]� -   $��canvas����. .+�o�  o� 
IsMainMenu . $	��Top=�.@�m� $
��File��.@�m�  m� Command$ ApplicationCommands.Print���� .+��� -   $��Palkki��$	��525��$��60�� �� Left$ 0��
 �� Top$ 0������  �� 
StartPoint$	 0,0&�	 �� EndPoint$		 0,1&�.��� 
 � Color$
 	#00000000�� � Offset$	 0.0Q�� $
 	#ff0000ff��$	 0.5Q�� $
 	#00000000��$	 1.0Q� � Triggers :�  :� RoutedEvent$ Rectangle.Loaded��.[��� .���� .��W�  �� 
TargetName$ Palkki�� �� TargetProperty$ (Canvas.Top)� W� From$ 0X�	 W� To$	 290X� g� Duration$ 0:0:4D� g� AutoReverse .  g� RepeatBehavior$ Forever���� -   $��
TekstiAlue��$ 10��$ 10��$	��450��$	��250���� -   $��Teksti��$��TIEA212��$ 0�� �� Bottom$ 10�� :� $ TextBlock.Loaded��.[��� .���� .��W� $ Teksti��$ (Canvas.Left)�$ 0X�$	 525X�$ 0:0:5D� . $ Forever��