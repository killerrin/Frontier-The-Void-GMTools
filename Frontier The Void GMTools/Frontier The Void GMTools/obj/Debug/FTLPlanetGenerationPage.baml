   M S B A M L   `   `   `  ����T  PFrontier The Void GMTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Frontier_The_Void_GMToolsFrontier_The_Void_GMTools  5      7    1Frontier_The_Void_GMTools.FTLPlanetGenerationPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Frontier_The_Void_GMTools     5        N� 
Background
  ����� N� Title$ FTL and Planet Generation��5	       � DataContext 5
      ��    Locator �� Source# [   �� Path$% vm_FTLPlanetGenerationViewModel�.��5      � .+�5   
   ]� .+�5      ��  �� Orientation$ Vertical=�6   $	��Top=�60   .+�5      �� $��FTL and Planet Generation��6   $��24(�6=   �� 5      $ 
Horizontal=�6   .+�5      �� $ Vertical=�6!   $��10,0,0,0q�68   .+�5      �� $��Hex Coordinates��6$   �� 5      $ 
Horizontal=�6%   $��0,5,0,0q�6>   .+�5      �� $��X��6(   $��0,0,5,0q�61   �� 5      -   5         ��Name$ hexXCoordinateTextBox��5   &   $��40��6E   6�   5      �� 5      $ 
Horizontal=�6%   $��0,5,0,0q�6>   .+�5      �� $��Y��6(   $��0,0,5,0q�61   �� 5      -   5        $ hexYCoordinateTextBox��5   &   $��40��6E   6�   5      5      �� 5      $ Vertical=�6!   $��20,0,0,0q�68   .+�5      �� $	��FTL��6$   $��Center=�6/   �� 5       $ 
Horizontal=�6%   $��0,5,0,0q�6>   .+�5!      �� $��Roll 1��6(   $��0,0,5,0q�66   �� 5"      -   5        $ ftlRoll1TextBox��5"   &   $��40��6?   6   5#      �� 5$      $ 
Horizontal=�6%   $��0,2,0,0q�6>   .+�5%      �� $��Roll 2��6(   $��0,0,5,0q�66   �� 5&      -   5        $ ftlRoll2TextBox��5&   &   $��40��6�   {�6?   ��  �� ElementName$ ftlExplorerCheckbox��$ 	IsChecked�6�   5'      �� 5(      -   5         ��Name$ ftlExplorerCheckbox��5(   #   $��Explorer��6@   	 d� 	IsChecked$	 FalseY�6S   $��0,2,0,0q�6e   �� 5)      -   5        $
��Roll��5)   !   $��50��60   $��0,2,0,0q�6U   5*      �� 5,      $ Vertical=�6!   $��20,0,0,0q�68   .+�5-      �� $��Planetary Generation��6$   $��Center=�6@   �� 5.      $ 
Horizontal=�6%   $��0,5,0,0q�6>   .+�5/      �� $��Roll 1��6(   $��0,0,5,0q�66   �� 50      -   5        $% planetaryGenerationRoll1TextBox��50   &   $��40��6O   6�   51      �� 52      $ 
Horizontal=�6%   $��0,2,0,0q�6>   .+�53      �� $��Roll 2��6(   $��0,0,5,0q�66   �� 54      -   5        $% planetaryGenerationRoll2TextBox��54   &   $��40��6O   6�   55      �� 56      $�� ��6$   $��0,2,0,0q�6.   �� 57      -	   5        $
��Roll��57   !   $��50��60   $��0,2,0,0q�6[   58      �� 5:      $ Vertical=�6!   $��20,0,0,0q�68   .+�5;      �� $��Generation Settings��6$   $��Center=�6?   �� 5<      -
   5        $" forceSentientSpeciesCheckBox��5<   #   $��Force Sentient Species��6I   $	 FalseY�6j   �� 5>      -   5        $ seedHexCheckBox��5>   #   $��Seed Hex��6<   $
	 TrueY�6O   $��0,10,0,0q�6`   �� 5?      -   5        $ seedFTLCheckBox��5?   #   $��Seed FTL Roll��6<   $	 FalseY�6T   �� 5@      -   5        $% seedPlanetaryGenerationCheckBox��5@   #   $$��Seed Planetary Generation Roll��6L   $	 FalseY�6u   �� 5B      $ 
Horizontal=�6%   $��0,5,0,0q�6>   .+�5C      �� -   5        $	��100��5C   %   $��Generate��61   6D   �� 5D      -   5        $��Clear��5D   %   $��5,0,0,0q�65   $��60��6F   6Q   5E      5F      5G      �� 5I      $ 
Horizontal=�6   $��0,20,0,0q�66   .+�5J      �� $��
FTL Result��6    $��0,0,5,0q�62   �� 5K      ��6    �� $ FTLTravelResult�  EnumSpaceConverter
 �� 	Converter#
 [ 5L      5M      �� 5O      -   5         ��Name$ generatedPlanets��5O      ��60   �� $ GeneratedSystem���5P      �� 5Q      .R�5R      �� $ 
Horizontal=�6%   $	��Top=�5S   %   $
��Left=�5T   %   5U      ��5X      �� 5Y      .R�5Z      �� $ Vertical=�6%   .+�5[      �� $ 
Horizontal=�6)   .+�5\   "   �� $	 FalseY�6+   �� 5]   "   $��5,0,0,0q�6{   ��6,   �� *Classification+#
 [ 6{   �� 5_   "   $��Radiation Level:��6,   $��20,0,5,0q�6D   �� 5`   "   ��6,   �� *	Radiation+#
 [ �� 5b   "   $��20,0,0,0q�6p   ��6,   �� *Age+#
 [ 6p   5c      �� 5e      ��6&   �� *CelestialBodies+��5f   "   �� 5g   &   .R�5h   *   �� $ Vertical=�65   .+�5i   .   �� $ 
Horizontal=�69   .+�5j   2   �� ��6<   �� *CelestialType+#
 [ �� 5k   2   $��20,0,0,0q�6�   ��6<   �� *TerraformingTier+#
 [ 6�   �� 5l   2   $��20,0,0,0q�6[   ��6<   �� *ResourceValue+6[   �� 5m   2   $��20,0,0,0q�6�   ��6<   �� *StageOfLife+#
 [ 6�   5n   /   �� 5p   .   ��66   �� *	Sentients+��5q   2   �� 5r   6   .R�5s   :   �� $ Vertical=�6E   .+�5t   >   �� $ 
Horizontal=�6I   .+�5u   B   �� ��6L   �� *	TechLevel+#
 [ �� 5w   B   $ Vertical=�6M   $��20,0,0,0q�6d   .+�5x   F   �� $��Civilization Traits��6P   $��Center=�6k   $��0,0,5,0q�6�   �� 5y   F   ��6N   �� *Traits+��5z   J   �� 5{   N   .R�5|   R   �� ��6\   �� #
 [ 5}   O   5   G   5�   C   �� 5�   B   $ Vertical=�6M   $��20,0,0,0q�6d   .+�5�   F   �� $��Race Classification��6P   $��Center=�6k   $��0,0,5,0q�6�   �� 5�   F   ��6N   �� *Classifications+��5�   J   �� 5�   N   .R�5�   R   �� ��6\   �� #
 [ 5�   O   5�   G   5�   C   5�   ?   5�   ;   5�   7   5�   /   5�   +   5�   '   5�      5�      5�      5�      5�      5�      5�      