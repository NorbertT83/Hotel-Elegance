    const pages = {
        dashboard: () => console.log("Irányítópult betöltése"),
        rooms: () => console.log("Housekeeping betöltése"),
        roomservice: () => console.log("Szobaszerviz betöltése"),
        services: () => console.log("Szolgáltatások betöltése"),
        foodbev: () => console.log("Étel/ital betöltése"),
        reception: () => console.log("Recepció betöltése"),
        settings: () => console.log("Beállítások betöltése"),
        logout: () => console.log("Kijelentkezés")
    };

    const navElements = document.querySelectorAll(".menuitem");
    const indicator = document.getElementById("menu-indicator");
    const customSelect = document.querySelector('#sort-by');
    const trigger = customSelect.querySelector('.select-trigger');
    const options = customSelect.querySelectorAll('.custom-option');
    const selectedText = document.querySelector('#selected-text');

    trigger.addEventListener('click', () => {
        customSelect.classList.toggle('open');
    });

    options.forEach(option => {
        option.addEventListener('click', () => {
            selectedText.innerText = option.innerText;
            
            options.forEach(el => el.classList.remove('selected'));
            option.classList.add('selected');
            
            customSelect.classList.remove('open');
            
            const val = option.dataset.option;
            console.log("Kiválasztva:", val);
        });
    });

    window.addEventListener('click', (e) => {
        if (!customSelect.contains(e.target)) {
            customSelect.classList.remove('open');
        }
    });



    function moveIndicator(target) {
        const menuRect = document.getElementById("menu").getBoundingClientRect();
        const targetRect = target.getBoundingClientRect();
        const offsetTop = targetRect.top - menuRect.top - (2.75*16); // menu felső margója
        indicator.style.transform = `translateY(${offsetTop}px)`;
        indicator.style.height = `${targetRect.height}px`;
    }

    const active = document.querySelector(".menuitem.selected");
    if (active) moveIndicator(active);

    navElements.forEach((item, index) => {
        item.addEventListener("click", () => {
            navElements.forEach(el => el.classList.remove("selected"));
            item.classList.add("selected");

            moveIndicator(item);

            const menuItem = item.dataset.menu;
            if (pages[menuItem]) {
                pages[menuItem]();
            }
        });

        item.addEventListener("mouseenter", () => {
            if (index >= navElements.length - 2) return;
            moveIndicator(item);
        });
        item.addEventListener("mouseleave", () => {
            const active = document.querySelector(".menuitem.selected");
            moveIndicator(active);
        });
    });