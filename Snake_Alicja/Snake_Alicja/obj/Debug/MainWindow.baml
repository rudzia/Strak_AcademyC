   M S B A M L   `   `   `  ����G  CSnake_Alicja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Snake_AlicjaSnake_Alicja  5   	       Snake_Alicja.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Snake_Alicja     5   	     � Title$  Settings snake game��5   	   $	��600��6%   $	��800��62    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � ��5   
   �� 5       �� ImageSource$i cC:\Users\Alicja\Documents\Visual Studio 2015\Projects\Snake_Alicja\Snake_Alicja\snakebackground.jpg��6    j� Stretch$ UniformToFill=�6�   .+�5   
   �� -   5         ��Name$ label��5      $
��Left=�6   $��	74,81,0,0q�6:   $	��Top=�6M   � 5   
   $��Center=�6   $	��550��6,   $	��Top=�6:   $	��750��6R   .+�5      �� -   5        $ 
label_user��5      $
��Left=�6(   $��105,166,0,0q�6C   $	��Top=�6X   $��70��6p   $	��173��6|   $��25(�6�   .��5      �� -   5        $ label1��5      $��	User name��6(   $1��+/Snake_Alicja;component/Fonts/#Chicken Butt)�6<   $	��165��6u   $��35(�6�   5      �� 5      -   5        $ label_colors��5      $��Choose snake color��6*   $
��Left=�6H   $��
10,251,0,0q�6c   $	��Top=�6w   $��62��6�   $	��268��6�   $��35(�6�   $1��+/Snake_Alicja;component/Fonts/#Chicken Butt)�6�   �� 5      -   5         ��Name$ textBoxUser��5      $
��Left=�6+   $��70��6F   $��301,166,0,0q�6R    �� TextWrapping$
 Wrap=�6g   $	��Top=�6|   $	��225��6�   ���	#FFCFF973$��25(�6�   $��Rockwell Extra Bold)�6�   �� 5      -   5         ��Name$ button_start��5      $��
START GAME��6+   $
��Left=�6@   $��172,392,0,0q�6[   $	��Top=�6p   $	��278��6�   $	��100��6�   $��30(�6�   $
��Bold"�6�   
���   �$��Rockwell Extra Bold)�6�   ��. ��5      �� 5      $i cC:\Users\Alicja\Documents\Visual Studio 2015\Projects\Snake_Alicja\Snake_Alicja\snakeTexturejpg.jpg��6!    �� Opacity$	 0.5Q�6�   $ UniformToFill=�6�   5      �� 5      -   5        $ 
labelSNAKE��5      $��Snake��6(      
CustomFont#��[  68   $��Center=�6\   $��221,0,172,0q�6y   $	��Top=�6�   $	��150(�6�   $	��161��6�   $	��357��6�   �� 5      -   5        $ 
labelAutor��5      $ ��Autor: Alicja Strąk, 2017��6(   $
��Left=�6L   $��
0,532,0,-8q�6g   $	��Top=�6{   $	��195��6�   �� 5      -	   5        $ buttonLegend��5      $��LEGEND��6+   $
��Left=�6<   $��171,330,0,0q�6W   $	��Top=�6l   $	��279��6�   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   $��53��6�   $��25(�6�   $
��Bold"�6�   $��Rockwell Extra Bold)�6�   
���   ���5      �� 5      $i cC:\Users\Alicja\Documents\Visual Studio 2015\Projects\Snake_Alicja\Snake_Alicja\snakeTexturejpg.jpg��6!   $	 0.5Q�6�   $ UniformToFill=�6�   5!      �� 5"      -
   5        $ 
buttonExit��5"      $
��EXIT��6)   $
��Left=�68   $��270,510,0,0q�6S   $	��Top=�6h   $��77��6�   ���	#FF7CA412$��20(�6�   $��Rockwell Extra Bold)�6�   $��30��6�   ���	#FF7CA4125$      �� 5%      -   5        
 ��Name$
 comboBoxColors��5%      $
��Left=�6/   $��301,251,0,0q�6J   $	��Top=�6_   $	��225��6w   $	 -0.483,-0.136&�6�   $��62��6�   ���	#FFCFF973���	#FFCFF973$��25(�6�   $��Rockwell Extra Bold)�6�   .@�5&      �� .��6   black6&   �� 5'      .��6   purple6'   �� 5(      .��6   orange6'   �� 5)      .��6   pink6%   �� 5*      .��6   white6&   5+      5,      5-      5.      