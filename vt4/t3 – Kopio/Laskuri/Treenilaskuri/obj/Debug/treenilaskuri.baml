   M S B A M L   `   `   `  ����H  DTreenilaskuri, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TreenilaskuriTreenilaskuri  5      F BTimeTextBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:TimeTextBox;assembly=TimeTextBoxTimeTextBox 5      H DNumberTextBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:NumberTextBox;assembly=NumberTextBoxNumberTextBox 6Q   D @PaceLabel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:PaceLabel;assembly=PaceLabel	PaceLabel 6�   !    Treenilaskuri.treenilaskuri   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Treenilaskuri     5      FTimeTextBox.clr-namespace:TimeTextBox;assembly=TimeTextBox     5      LNumberTextBox2clr-namespace:NumberTextBox;assembly=NumberTextBox     6Q   @	PaceLabel*clr-namespace:PaceLabel;assembly=PaceLabel     6�     � DataContext  5
      ��  �� RelativeSource �� *Self+.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Aika (hh:mm:ss)��6   $��0��6*   $��0��67   $��Right=�6G   $��Center=�6c   �� 5   
   $��
Matka (km)��6   $��1��6%   $��0��62   $��Right=�6B   $��Center=�6^   �� 5   
   $��Vauhti (min/km)��6   $��2��6*   $��0��67   $��Right=�6G   $��Center=�6c     TimeTextBox.timeTextBox  5   
   -   5          Name$ timeTextBox��5   u   $��0��6"   $��1��6/   $
��Left=�6?   $��Center=�6Z   $��0,5,0,5q�6�   !  NumberTextBox.numberTextBox  5   
   -   5          Name$ numberTextBox��5   z   $��1��6&   $��1��63   $
��Left=�6C   $��Center=�6^   $��0,5,0,5q�6�     PaceLabel.paceLabel  5   
   $��2��6   $��1��6+   $
��Left=�6;   $��Center=�6V   $��0,0,0,0q�6�      Distance 6r   �� *Number+ �� ElementName$ numberTextBox��   Time 6�   �� *Time+$ timeTextBox��5      5      