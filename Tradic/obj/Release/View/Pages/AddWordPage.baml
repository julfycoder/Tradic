   M S B A M L   `   `   `  ���� 
  Tradic#    Tradic.View.Pages.AddWordPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� ShowsNavigationUI  .   N� 
Background �	#FF931313 N� Title$ AddWordPage��.��� $
��Left=�$	��814��$	��515��$	��Top=�.+��� $��Original language��$
��Left=�$��
116,93,0,0q�$	��Top=����	#FFCBEA60$��18(�$
��Bold"��� $��Translation language��$
��Left=�$��
549,93,0,0q�$	��Top=����	#FFCBEA60$��18(�$
��Bold"��� $��Translation word��$
��Left=�$��549,229,0,0q�$	��Top=����	#FFCBEA60$��18(�$
��Bold"��� $��Original word��$
��Left=�$��116,229,0,0q�$	��Top=����	#FFCBEA60$��18(�$
��Bold"��� -    ��Name$ OrigianlWordBox��$
��Left=�$��116,260,0,229q� �� TextWrapping$
 Wrap=�$	��161�����	#FFE48484$��18(�$
��Bold"�����  �� Path$ OriginalWordText� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.�� J� InputBindings �� 
	 �� Key$	 Enter��
 �� Command
 �� $ AddNewWordCommand�.���� -   $ TranslationWordsBox��$
��Left=�$��549,260,0,0q�$
 Wrap=�$	��187�����	#FFE48484$��18(�$
��Bold"�$��26��$	��Top=����� $ TranslationWordText�$ TwoWay=�$ PropertyChanged=�.�� �� $	 Enter��
 �� $ AddNewWordCommand�.���� -    ��Name$ OriginalLanguagesBox��$
��Left=�$��87��$��116,124,0,0q�$	��Top=�$	��161��$��18(����	#FFE48484$
��Bold"����� $ OriginalLanguages�$ TwoWay=� �� SelectedItem �� $ SelectedOriginalLanguage�$ TwoWay=����� .R��� ���� $
 Name��� -   $ TranslationLanguagesBox��$��87��$��549,124,78,0q�$	��Top=����	#FFE48484$��18(�$
��Bold"����� $ TranslationLanguages�$ TwoWay=� �� $! SelectedTranslationLanguage�$ TwoWay=����� .R��� ���� $
 Name��� -    ��Name$ WatchButton��$��
Dictionary��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��157��$��46��
��� ���
��� ���$
��Bold"�
��� ��� � Cursor$
 Hand��$��18(����� $ GoToMainPageCommand��� $��Add Word��$
��Left=�$��305,349,0,0q�$	��Top=�$	��200��$��47�����	#FF0FC96C
��� ���$
��Bold"����	#FF0FC96C$
 Hand��$��16(����� $ AddNewWordCommand�