const card = document.createElement('div');
card.className = "property-card";
const styles = `
    .property-card {
        width: 350px;
        font-family: sans-serif;
        border-radius: 15px;
        overflow: hidden;
        box-shadow: 0 4px 10px rgba(0,0,0,0.1);
        margin: 20px auto;
        border: 1px solid #eee;
    }
    .card-image {
        height: 200px;
        background: url('https://images.unsplash.com/photo-1518780664697-55e3ad937233?w=400') center/cover;
        position: relative;
    }
    .heart-icon {
        position: absolute; top: 15px; right: 15px;
        color: white; font-size: 24px; cursor: pointer;
    }
    .card-body { padding: 20px; }
    .type { font-size: 12px; font-weight: bold; color: #555; }
    .price { font-size: 28px; font-weight: bold; margin: 10px 0; }
    .address { color: #888; margin-bottom: 15px; }
    .stats { border-top: 1px solid #eee; padding-top: 15px; display: flex; gap: 15px; color: #444; }
    .realtor { background: #f9f9f9; padding: 15px 20px; display: flex; align-items: center; gap: 10px; }
    .avatar { width: 40px; height: 40px; border-radius: 50%; }
`;

const styleSheet = document.createElement("style");
styleSheet.innerText = styles;
document.head.appendChild(styleSheet);
card.innerHTML = `
    <div class="card-image">
        <span class="heart-icon" onclick="this.style.color = this.style.color == 'red' ? 'white' : 'red'">❤</span>
    </div>
    <div class="card-body">
        <div class="type">DETACHED HOUSE • 5Y OLD</div>
        <div class="price">$750,000</div>
        <div class="address">742 Evergreen Terrace</div>
        <div class="stats">
            <span>🛏 3 Bedrooms</span>
            <span>🛁 2 Bathrooms</span>
        </div>
    </div>
    <div class="realtor">
        <img src="https://i.pravatar.cc/100" class="avatar">
        <div>
            <div style="font-weight:bold">Tiffany Heffner</div>
            <div style="font-size:12px; color:#999">(555) 555-4321</div>
        </div>
    </div>
`;
document.body.appendChild(card);