   M S B A M L   `   `   `  ����G  CMultiFenetre, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MultiFenetreMultiFenetre  5   	       MultiFenetre.Data_gestion   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MultiFenetre     5   	     � Title$  Data_gestion��5   	   $	��450��6   $	��800��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��43* �6   �� 5      $��8* �6   �� 5      $
��147* �6   �� 5      $��7* �6   �� 5      $
��215* �6   �� 5      $	��14* �6    � ColumnDefinitions 5   
   �� 5      $	��12* �6   �� 5      $
��569* �6   �� 5      $��9* �6   �� 5      $
��189* �6   �� 5      $	��10* �6   �� 5      $	��11* �6   .+�5   
   �� $��Details��6   $��4��6$   $��1��61   5      �� 5   
   $��1��6   $��3��6    $��Actions��60   $��0,8,0,0q�6A   $��2��6R   .��5      �  5      �� 5       $��2* �6$   �� 5!      $��8* �6$   �� 5"      $��2* �6$   �� 5#      $��8* �6$   �� 5$      $��2* �6$    5&      �� 5'      $	��20* �6'   �� 5(      $
��133* �6'   �� 5)      $	��24* �6'   .+�5+      �� $��1��6   $��Stretch=�6*   $��1��6I   .��5,      �� $��+��6    $��32(�6.   
��� � �$!��#/Font Awesome 6 Free Solid)�6O   6z   5-      5.      50      &   System.Windows.Controls.DataGrid  51   
   -   5          Name$ 
dtg_Photos��51   0   $��1��6   $��1��6       AutoGenerateColumns$ false��6D      
IsReadOnly$
 true��6`   $��0,8,0,0q�6r   $��2��6�      Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$ photo��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Name+  54      $
 date��6%    63   �� *Date+56      �� 57   
   $��1��6   $��Liste des photos��6    $
��Left=�6;   $��Center=�6V   $��20(�6q   $��	312,0,0,0q�6   58      59      