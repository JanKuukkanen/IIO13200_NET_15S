   M S B A M L   `   `   `  ����C  ?Teht4XML, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Teht4XMLTeht4XML  5   	       Teht4XML.Viinikellari1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Teht4XML     5   	     � Title$  Viinikellari1��5   	   $��431.571��6   $��515.219��60   .��5	      � $��0,0,2,0q�6    � 	Resources 5
   
      
viinidataa � Source � XPath��%Z   &	        � 5      $ D://H3387/Viinit.xml?�61   $ viinikellari/wine��6O   6k   5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgWines��5       � DataContext# [  6$      AutoGenerateColumns .  $��	0,60,0,31q�6�    J� RenderTransformOrigin$ 0.528,0.499&�6�   ��6N   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Viini��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   ��  �� XPath$
 nimi��6U     5      $		 Maa��6%   
 62   �� $	 maa��6R     5      $	 Pisteet��6%   
 66   �� $ arvio��6X   5      �� 5   
   -   5         ��Name$ btnGetWines��5      $��
Hae Viinit��6&   $
��Left=�6;   $��	10,22,0,0q�6V   $	��Top=�6i   $	��100��6�   �� 5   
   -   5         ��Name$ 
cmbCountry��5      $
��Left=�6'   $��
375,22,0,0q�6B   $	��Top=�6V   $	��120��6n   6z   5      5      