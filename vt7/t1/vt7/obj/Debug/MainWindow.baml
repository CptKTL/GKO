   M S B A M L   `   `   `  ����>  :vt7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:vt7vt7  5   	       vt7.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:vt7     5   	   -   5          �Name$  window��5   	    � Title$ 
MainWindow��5   	   $	��350��6   $	��525��6)    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$ ApplicationCommands.Print��5
      6Y   .��5      ]� -   5        $��canvas��5      ��. .+�5   
   o�  o� 
IsMainMenu . $	��Top=�6!   .@�5      m� $
��File��6   .@�5      m�  m� Command$ ApplicationCommands.Print��6   6A   5      5      �� 5   
   .+�5      �� -   5        $��Palkki��5      $	��525��6&   $��60��62    �� Left$ 0��6>   
 �� Top$ 0��6N   ��5      �� 5       �� 
StartPoint$	 0,0&�6*   	 �� EndPoint$		 0,1&�6;   .��5      � 
 � Color$
 	#00000000��6'    � Offset$	 0.0Q�69   6H   � 5      $
 	#ff0000ff��6'   $	 0.5Q�69   6H   � 5      $
 	#00000000��6'   $	 1.0Q�69   6H   5       � Triggers 5      :� 5       :� RoutedEvent$ Rectangle.Loaded��6#   .[�5       �� .��5!      �� .��5"   "   W�  �� 
TargetName$ Palkki��62    �� TargetProperty$ (Canvas.Top)�5#   .    W� From$ 0X�5$   .   	 W� To$	 290X�67    g� Duration$ 0:0:4D�6@    g� AutoReverse .  g� RepeatBehavior$ Forever��5%   A   5&      5'      5(      5*      �� 5,      -   5        $��
TekstiAlue��5,      $ 10��6,   $ 10��6<   $	��450��6M   $	��250��6Y   6h   �� 5.      -   5        $��Teksti��5.      $��TIEA212��6&   $ 0��65    �� Bottom$ 10��6E    5/      :� 50      $ TextBlock.Loaded��6#   .[�51      �� .��52      �� .��53   "   W� $ Teksti��54      $ (Canvas.Left)�55   !   $ 0X�56   !   $	 525X�6*   $ 0:0:5D�63    . $ Forever��57   4   58      59      5:      5<      5=      5>      5?      