function Print(array){
    array.sort();

    array.sort(Compare);

    function Compare(a, b){
        return String(a).length - String(b).length;
    }

    console.log(array.join('\n'));
}

Print(['alpha', 
'beta', 
'gamma']
);