function Print(input) {
 
    let stored = new Set();
 
    for (let user of input)
    {
        let sor = JSON.parse(user).sort((a,b)=>b-a);
        stored.add(JSON.stringify(sor));
    }
 
    let res = [];
    stored.forEach(f=>res.push(JSON.parse(f)));
 
    res.sort((a,b)=> a.length-b.length);
 
    res.forEach(f=> console.log(`[${f.join(', ')}]`));
 
}
Print(["[-3, -2, -1, 0, 1, 2, 3, 4]",
"[10, 1, -17, 0, 2, 13]",
"[4, -3, 3, -2, 2, -1, 1, 0]"]
);