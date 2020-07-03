function Sort(array){

    array = array.filter((x, i, a) => a.indexOf(x) == i)

    array.sort();

    array.sort((a, b) => a.length - b.length);

    console.log(array.join('\n'));
}

Sort(['Ashton',
'Kutcher',
'Ariel',
'Lilly',
'Keyden',
'Aizen',
'Billy',
'Braston',
'Ashton']
);