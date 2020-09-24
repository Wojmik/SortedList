# Sorted List

Repository for extremally fast binary searching in sorted list for .Net. It is like database clustered index.

Regular .Net searchable lists like HasSet&lt;T&gt; or Dictionary&lt;T&gt; – based on equality, are able to search only by equality condition. Grater or less conditions are impossible. Searching by part of the key is impossible also.

Sorted list on the other hand, can be searched by equal, greater, greater or equal, less and less or equal conditions. It is also possible to search by part of the key under certain conditions.

Very simple example of sorted list is old fashioned phonebook. Phonebook is sorted by surname, first name and street address. Phonebook can be searched by surname, first name and street address but it can be also searched by surname and first name only (without street address) or by surname only. You only have to follow key order – surname, first name and street address. You cannot skip surname and search only by first name.

In phonebook you can also search by greater and less criterions. Let's say you want  to find all records from Smith Carolina to Smith John. It is perfectly possible.

Just imagine – phonebooks can contain hundreds thousands of records but it is pretty easy for human to find one particular entry. That is the power of binary search.

# SortedReadOnlyList

Repository contains very simple to use SortedReadOnlyList type in WojciechMikołajewicz.SortedList namespace.

