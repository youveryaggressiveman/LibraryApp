   M S B A M L   `   `   `  ����E  ALibraryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:LibraryApp
LibraryApp  5   	       LibraryApp.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:LibraryApp     5   	     � WindowStartupLocation$  CenterScreen=�5   	   
������� � Title$3 -Библиотека: Главное окно��5
   	   $	��600��6*   $
��1000��67   $	��600��5   	   $
��1000��5   	   $��Rubik)�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      .+�5   
   �� $
��Left=�6   $��Center=�5      $��15 0 0 0q�5      $��2��5       �� Orientation$ 
Horizontal=�5      .+�5      �� $&�� ../../Assets/Images/Logotype.png��6   $��50��5      $��	 0 0 10 0q�5      �� 5      $��Главное окно��6   $��30(�5       $
��Bold"�5!      $
��Left=�5"      $��Center=�5#      5$      �� 5%   
   -   5        $��userInfoStackPanel��5&      $��1��5%      $��Center=�5'      $��Right=�5(      $��15q�5)      .+�5,      ��  �� CornerRadius$ 8��6   $	��300��5-      $��85��5.       �� Padding$ 5q�5/      $��1q�50      ���#a3a3a4._�52      �  53      �� 54      �� 55      .+�57      �� -   5        $��fullNameTextBlock��58      $��Center=�59      $��21(�5:      �� 5;      $�ФИО:��6   $��SemiBold"�5<       �� 5=      �6   �� *
FullName+5>      �� 5?      -   5        $��roleTextBlock��5A       $��Center=�5?       $��1��5@       $��18(�5B       �� 5C      $�	Роль:��6   $��SemiBold"�5D       �� 5E      �6   �� *Role+5F      5G      5H      5I       � 5J   
   -   5        $��	mainFrame��5L      $��1��5J      $��1��5K      $��15q�5M      ��5N      �� 5O       �� 
TargetType"  �6   .�5P      ��  �� Property � ��	 �� Value	 �#a3a3a45Q      �� 5R       � ��$	 1q�5S      �� 5T       � ��	 5U      �� 5V      
 �� 
TargetType"
  �6.   .R�5W   "   �� $ 8��6)   #��z��5X   )   #��z��5Y   )   #��z��5Z   )   ._�5[   &   �� 5\   #   5]      5_      5`      5b      5c      5d      